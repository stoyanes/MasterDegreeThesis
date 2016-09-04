using Server.Business.Dto;
using Server.Data.Model;
using AutoMapper;
using System;
using Server.Data.Enums;
using System.Collections.Generic;
using Server.Business.Interfaces;
using System.Linq;
using Server.Business.Configs;
using Microsoft.Practices.Unity;

namespace Server.Business.Services
{
    public class VacationRequestService : BaseBusinessService<VacationRequest, VacationRequestDto>, IVacationRequestService
    {
        private IHolidayService holidayService  = new HolidayService();
        private IAdditionalWorkingDaysService additionalWroingDaysService = new AdditionalWorkingDaysService();
        private IEmployeeService employeeService = new EmployeeService();
        private ILeaveDaysService leaveDaysService = new LeaveDaysService();

        //public VacationRequestService()
        //    : base(entity)
        //{
        //}

        public VacationRequestService(IHolidayService hs, IAdditionalWorkingDaysService aws, IEmployeeService es, ILeaveDaysService ld)
        {
            holidayService = hs;
            additionalWroingDaysService = aws;
            employeeService = es;
            leaveDaysService = ld;
        }

        private IList<DateTime> GetWorkingDays(DateTime startDate, DateTime endDate, IList<VacationRequestDto> currentVacationRequests)
        {
            IList<DateTime> workingDates = new List<DateTime>();
            IList<HolidayDto> holidays = holidayService.GetForYear(startDate.Year).ToList();
            IList<AdditionalWorkingDayDto> additionalWorkingDays = additionalWroingDaysService.GetAllForYear(startDate.Year).ToList();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                bool isDayHoliday = holidays.Any(holiday => holiday.WorkingDate == date);
                bool isWeekendDay = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                bool isAdditionalWorkingDay = additionalWorkingDays.Any(addWorkingDay => addWorkingDay.WorkingDate == date);
                bool isAlreadyRequested = currentVacationRequests.Any(vacationReq => vacationReq.StartDate <= date && vacationReq.EndDate >= date);

                if (isAdditionalWorkingDay && !isAlreadyRequested)
                {
                    workingDates.Add(date);
                }
                else if (!isDayHoliday && !isWeekendDay && !isAlreadyRequested)
                {
                    workingDates.Add(date);
                }
            }

            return workingDates;
        }

        public override int CreateEntity(VacationRequestDto newEntity)
        {
            VacationRequest vacationRequestToCreate = Mapper.Map<VacationRequest>(newEntity);

            vacationRequestToCreate.Status = RequestStates.Submitted;

            LeaveDaysDto empLeaveDays = leaveDaysService.GetAllForEmployeeByYear(vacationRequestToCreate.EmployeeID, vacationRequestToCreate.StartDate.Year);

            if (empLeaveDays.TakenPaidDays >= empLeaveDays.AllowedPaidDays)
            {
                throw new Exception("Employee does not have enought paid days.");
            }

            if (empLeaveDays.TakenNonPaidDays >= empLeaveDays.AllowedNonPaidDays)
            {
                throw new Exception("Employee does not have enought non-paid days.");
            }

            IList<DateTime> workingDays = this.GetWorkingDays(vacationRequestToCreate.StartDate, vacationRequestToCreate.EndDate, this.GetAllForEmployeeByYear(vacationRequestToCreate.EmployeeID, vacationRequestToCreate.StartDate.Year));

            if (workingDays.Count == 0)
            {
                return -1;
            }

            if (vacationRequestToCreate.VacationType == VacationType.Paid)
            {
                if (empLeaveDays.TakenPaidDays + workingDays.Count > empLeaveDays.AllowedPaidDays)
                {
                    throw new Exception("Requested days are more than left.");
                }

                empLeaveDays.TakenPaidDays += workingDays.Count;
            }
            else if (vacationRequestToCreate.VacationType == VacationType.Unpaid)
            {
                if (empLeaveDays.AllowedNonPaidDays < workingDays.Count + empLeaveDays.TakenNonPaidDays)
                {
                    throw new Exception("Requested days are more than allowed.");
                }
                empLeaveDays.TakenNonPaidDays += workingDays.Count;
            }
            else if (vacationRequestToCreate.VacationType == VacationType.Sickness)
            {
                empLeaveDays.SickDays += workingDays.Count;
                vacationRequestToCreate.Status = RequestStates.Approved;
            }
            else if (vacationRequestToCreate.VacationType == VacationType.BloodDonation ||
                     vacationRequestToCreate.VacationType == VacationType.Marriage ||
                     vacationRequestToCreate.VacationType == VacationType.Death)
            {
                empLeaveDays.AllowedPaidDays += 2;
                empLeaveDays.TakenPaidDays += 2;
                vacationRequestToCreate.Status = RequestStates.Approved;
            }
            else if (vacationRequestToCreate.VacationType == VacationType.Other)
            {
                empLeaveDays.OtherDays += workingDays.Count;
            }

            VacationRequest createdEntity = entityRepository.Create(vacationRequestToCreate);
            entityRepository.SaveChanges();
            leaveDaysService.UpdateEntity(empLeaveDays);
            return createdEntity.Id;
        }

        public override bool DeleteEntityById(int id)
        {
            VacationRequest vacReq = this.entityRepository.FindById(id);

            LeaveDaysDto empLeaveDaysForYear = leaveDaysService
                                                .GetAllForEmployeeByYear(vacReq.EmployeeID, vacReq.EndDate.Year);

            int totalDaysToDelete = 0;

            if (vacReq.StartDate == vacReq.EndDate)
            {
                totalDaysToDelete = 1;
            } else
            {
                totalDaysToDelete = (int)Math.Floor((vacReq.EndDate - vacReq.StartDate).TotalDays) + 1;
            }

            if (empLeaveDaysForYear != null)
            {
                switch (vacReq.VacationType)
                {
                    case VacationType.Unpaid:
                        empLeaveDaysForYear.TakenNonPaidDays -= totalDaysToDelete;
                        break;
                    case VacationType.Sickness:
                        empLeaveDaysForYear.SickDays -= totalDaysToDelete;
                        break;
                    case VacationType.Paid:
                    case VacationType.Marriage:
                    case VacationType.BloodDonation:
                    case VacationType.Death:
                    case VacationType.Motherhood:
                        empLeaveDaysForYear.TakenPaidDays -= totalDaysToDelete;
                        break;
                    default:
                        break;
                }

                leaveDaysService.UpdateEntity(empLeaveDaysForYear);
            }

            this.entityRepository.Delete(vacReq.Id);
            return this.entityRepository.SaveChanges();
        }

        public IList<VacationRequestDto> GetAllForEmployeeByYear(int employeeId, int year)
        {
            var vacationReqs = this.entityRepository
               .FindAll(vacationReq => 
                    vacationReq.EmployeeID == employeeId 
                    && (vacationReq.StartDate.Year == year && vacationReq.EndDate.Year == year
                        || (vacationReq.StartDate.Year == year && vacationReq.EndDate.Year == year + 1))
               )
               .ToList();
            var resVacReqs = Mapper.Map<List<VacationRequestDto>>(vacationReqs);
            return resVacReqs;
        }

        public IList<VacationRequestDto> GetRequestsToApprove(int approvalManagerId)
        {
            IList<EmployeeDto> employeesToManage = this.employeeService.GetAll().Where(employee => employee.Manager != null && employee.Manager.Id == approvalManagerId).ToList();
            var vacationRequestsNotApproved = this.
                entityRepository
                .FindAll(vacationReq => vacationReq.Status == RequestStates.Submitted).ToList();
            var vacReqNotApprovedForApprManager = vacationRequestsNotApproved.Where(vacationReq => employeesToManage.Any(emp => emp.Manager != null && emp.Manager.Id == approvalManagerId && emp.Id == vacationReq.EmployeeID)).ToList();
            var resultRequests = Mapper.Map<List<VacationRequestDto>>(vacReqNotApprovedForApprManager);
            return resultRequests;
        }

        public IList<VacationRequestDto> GetAllForEmployee(int employeeId)
        {
            var vacationReqs = this.entityRepository.FindAll(vacReq => vacReq.EmployeeID == employeeId);
            var resVacationReq = Mapper.Map<List<VacationRequestDto>>(vacationReqs);
            return resVacationReq;
        }
    }
}
