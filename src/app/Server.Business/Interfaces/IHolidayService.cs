using Server.Business.Dto;
using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface IHolidayService : IBaseBusinessService<HolidayDto>
    {
        IEnumerable<HolidayDto> GetForYear(int year);
    }
}
