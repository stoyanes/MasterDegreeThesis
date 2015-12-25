using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Business.Dto;
using Server.Data.Model;

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
                cfg.CreateMap<Holiday, HolidayDto>();

                cfg.CreateMap<HolidayDto, Holiday>();
                cfg.CreateMap<Holiday, HolidayDto>();

                cfg.CreateMap<LeaveDaysDto, LeaveDays>();
                cfg.CreateMap<LeaveDays, LeaveDaysDto>();

                cfg.CreateMap<VacationRequestDto, VacationRequest>();
                cfg.CreateMap<VacationRequest, VacationRequestDto>();
            });
        }
    }
}
