using Server.Business.Dto;
using Server.Data.Model;
using AutoMapper;
using System;
using Server.Data.Enums;

namespace Server.Business.Services
{
    public class VacationRequestService: BaseBusinessService<VacationRequest, VacationRequestDto>
    {
        public override int CreateEntity(VacationRequestDto newEntity, int? employeeId)
        {
            if (!employeeId.HasValue)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            VacationRequest vacationRequestToCreate = Mapper.Map<VacationRequest>(newEntity);
            vacationRequestToCreate.EmployeeID = employeeId.Value;
            vacationRequestToCreate.CreatedDate = DateTime.Now;
            vacationRequestToCreate.Status = RequestStates.Submitted;
            VacationRequest createdEntity = entityRepository.Create(vacationRequestToCreate);
            entityRepository.SaveChanges();
            return createdEntity.Id;
        }
    }
}
