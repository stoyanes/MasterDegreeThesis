using Server.Business.Dto;
using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface IVacationRequestService : IBaseBusinessService<VacationRequestDto>
    {
        IList<VacationRequestDto> GetAllForEmployeeByYear(int employeeId, int year);
        IList<VacationRequestDto> GetRequestsToApprove(int approvalManagerId);
        IList<VacationRequestDto> GetAllForEmployee(int employeeId);
    }
}
