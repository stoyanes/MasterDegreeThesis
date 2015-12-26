using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;
using Server.Data.Enums;

namespace Server.Business.Services
{
    public class VacationRequestService: IBaseBusinessService<VacationRequestDto> 
    {
        private IRepository<VacationRequest> entityRepository = new Repository<VacationRequest>(new ApplicationDbContext());

        public IEnumerable<VacationRequestDto> GetAll()
        {
            var entities = entityRepository
                            .FindAll()
                            .ToList();
            var resultEntities = Mapper.Map<List<VacationRequestDto>>(entities);
            return resultEntities;
        }

        public VacationRequestDto GetById(int id)
        {
            var entity = entityRepository.FindById(id);
            var resultEntity = Mapper.Map<VacationRequestDto>(entity);

            return resultEntity;
        }

        public int CreateEntity(VacationRequestDto newEntity, int? employeeId)
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


        public bool UpdateEntity(VacationRequestDto newEntity)
        {
            VacationRequest vacationRequestToUpdate = Mapper.Map<VacationRequest>(newEntity);
            entityRepository.Update(vacationRequestToUpdate);
            bool updateResult = entityRepository.SaveChanges();
            return updateResult;
        }

        public bool DeleteEntityById(int id)
        {
            entityRepository.Delete(id);
            bool deleteResult = entityRepository.SaveChanges();
            return deleteResult;
        }
    }
}