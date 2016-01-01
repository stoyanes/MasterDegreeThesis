using System;
using System.Collections.Generic;
using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data.Model;
using System.Linq;
using AutoMapper;

namespace Server.Business.Services
{
    public class HolidayService : BaseBusinessService<Holiday, HolidayDto>, IHolidayService
    {
        public IEnumerable<HolidayDto> GetForYear(int year)
        {
            var holidays = this.entityRepository
                .FindAll()
                .Where(holiday => holiday.HolidayDate.Year == year)
                .ToList();
            var resultHolidays = Mapper.Map<List<HolidayDto>>(holidays);
            return resultHolidays;
        }
    }
}
