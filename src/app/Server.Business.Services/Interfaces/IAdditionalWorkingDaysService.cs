using Server.Business.Dto;
using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface IAdditionalWorkingDaysService : IBaseBusinessService<AdditionalWorkingDayDto>
    {
        IEnumerable<AdditionalWorkingDayDto> GetAllForYear(int year);
    }
}
