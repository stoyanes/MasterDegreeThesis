using Server.Business.Dto;
using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface IVacationRequestService
    {
        IEnumerable<VacationRequestDto> GetAll();

        VacationRequestDto GetById(int id);

        int CreateEntity(int employeeId, VacationRequestDto newEntity);

        bool UpdateEntity(VacationRequestDto newEntity);

        bool DeleteEntityById(int id);
    }
}
