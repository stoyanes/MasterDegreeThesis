using Server.Business.Dto;

namespace Server.Business.Interfaces
{
    public interface IEmployeeService : IBaseBusinessService<EmployeeDto>
    {
        bool UpdateLeaveDaysForYear(int employeeId, int year, LeaveDaysDto leaveDays);
    }
}
