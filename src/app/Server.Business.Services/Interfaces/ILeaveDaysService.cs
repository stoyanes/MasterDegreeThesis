using Server.Business.Dto;
using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface ILeaveDaysService : IBaseBusinessService<LeaveDaysDto>
    {
        IEnumerable<LeaveDaysDto> GetAllForEmployee(int employeeId);

        LeaveDaysDto GetAllForEmployeeByYear(int employeeId, int year);
    }
}
