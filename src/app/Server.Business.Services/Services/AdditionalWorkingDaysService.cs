using System;
using System.Collections.Generic;
using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data.Model;
using System.Linq;
using AutoMapper;

namespace Server.Business.Services
{
    public class AdditionalWorkingDaysService: BaseBusinessService<AdditionalWorkingDay, AdditionalWorkingDayDto>, IAdditionalWorkingDaysService
    {
        public IEnumerable<AdditionalWorkingDayDto> GetAllForYear(int year)
        {
            var additionalWorkingDays = this.entityRepository
                .FindAll()
                .Where(additionalWorkingDay => additionalWorkingDay.WorkingDate.Year == year)
                .ToList();
            var resultHolidays = Mapper.Map<List<AdditionalWorkingDayDto>>(additionalWorkingDays);
            return resultHolidays;
        }
    }
}
