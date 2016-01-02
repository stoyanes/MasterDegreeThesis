using Server.Business.Dto;
using Server.Data.Model;
using AutoMapper;
using System;
using Server.Data.Enums;
using System.Collections.Generic;
using Server.Business.Interfaces;
using System.Linq;

namespace Server.Business.Services
{
    public class VacationRequestService : BaseBusinessService<VacationRequest, VacationRequestDto>
    {
        private IHolidayService holidayService = new HolidayService();
        private IAdditionalWorkingDaysService additionalWroingDaysService = new AdditionalWorkingDaysService();
        private IEmployeeService employeeService = new EmployeeService();
        private ILeaveDaysService leaveDaysService = new LeaveDaysService();

        private IList<DateTime> GetWorkingDays(DateTime startDate, DateTime endDate)
        {
            IList<DateTime> workingDates = new List<DateTime>();
            IList<HolidayDto> holidays = holidayService.GetForYear(startDate.Year).ToList();
            IList<AdditionalWorkingDayDto> additionalWorkingDays = additionalWroingDaysService.GetAllForYear(startDate.Year).ToList();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                bool isDayHoliday = holidays.Any(holiday => holiday.WorkingDate == date);
                bool isWeekendDay = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                bool isAdditionalWorkingDay = additionalWorkingDays.Any(addWorkingDay => addWorkingDay.WorkingDate == date);

                if (isAdditionalWorkingDay)
                {
                    workingDates.Add(date);
                }
                else if (!isDayHoliday && !isWeekendDay)
                {
                    workingDates.Add(date);
                }
            }

            return workingDates;
        }
        public override int CreateEntity(VacationRequestDto newEntity)
        {
            VacationRequest vacationRequestToCreate = Mapper.Map<VacationRequest>(newEntity);
            vacationRequestToCreate.CreatedDate = DateTime.Now;
            vacationRequestToCreate.Status = RequestStates.Submitted;

            EmployeeDto employee = employeeService.GetById(vacationRequestToCreate.EmployeeID);
            LeaveDaysDto empLeaveDays = leaveDaysService.GetAllForEmployeeByYear(employee.Id, vacationRequestToCreate.StartDate.Year);

            if (empLeaveDays.TakenPaidDays == 0)
            {
                throw new Exception("Employee does not have enought paid days.");
            }

            if (empLeaveDays.TakenNonPaidDays == 0)
            {
                throw new Exception("Employee does not have enought non-paid days.");
            }

            IList<DateTime> workingDays = this.GetWorkingDays(vacationRequestToCreate.StartDate, vacationRequestToCreate.EndDate);

            if (vacationRequestToCreate.VacationType == VacationType.Paid)
            {

            }
            else if (vacationRequestToCreate.VacationType == VacationType.Unpaid)
            {

            }
            else if (vacationRequestToCreate.VacationType == VacationType.Sickness)
            {

            }

            VacationRequest createdEntity = entityRepository.Create(vacationRequestToCreate);
            entityRepository.SaveChanges();
            return createdEntity.Id;
        }
    }
}
