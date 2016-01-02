using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Business.Dto;
using Server.Data.Model;
using Server.Data.Repositories;

namespace Server.Business.Configs
{
    public static class AutoMapperBusinessConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AdditionalWorkingDayDto, AdditionalWorkingDay>();
                cfg.CreateMap<AdditionalWorkingDay, AdditionalWorkingDayDto>();

                cfg.CreateMap<EmployeeDto, Employee>();
                cfg.CreateMap<Employee, EmployeeDto>();

                cfg.CreateMap<HolidayDto, Holiday>();
                cfg.CreateMap<Holiday, HolidayDto>();

                cfg.CreateMap<LeaveDaysDto, LeaveDays>();
                cfg.CreateMap<LeaveDays, LeaveDaysDto>();

                cfg.CreateMap<VacationRequestDto, VacationRequest>();
                //.ConstructUsing((VacationRequestDto vacationReqDto) =>
                //{
                //    IRepository<Employee> empRepo = new Repository<Employee>();
                //    VacationRequest mappedVacationRequest = new VacationRequest()
                //    {
                //        Description = vacationReqDto.Description,
                //        EmployeeID = vacationReqDto.EmployeeID,
                //        StartDate = vacationReqDto.StartDate,
                //        EndDate = vacationReqDto.EndDate,
                //        VacationType = vacationReqDto.VacationType
                //    };

                //    mappedVacationRequest.Employee = empRepo.FindById(vacationReqDto.EmployeeID);
                //    return mappedVacationRequest;
                //});
                cfg.CreateMap<VacationRequest, VacationRequestDto>();
            });
        }
    }
}
