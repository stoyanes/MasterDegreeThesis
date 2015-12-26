using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;

namespace Server.Business.Services
{
    public class LeaveDaysService : ILeaveDaysService
    {
        private IRepository<LeaveDays> entityRepository = new Repository<LeaveDays>(new ApplicationDbContext());

        public IEnumerable<LeaveDaysDto> GetAll()
        {
            var entities = entityRepository
                            .FindAll()
                            .ToList();
            var resultEntities = Mapper.Map<List<LeaveDaysDto>>(entities);
            return resultEntities;
        }

        public LeaveDaysDto GetById(int id)
        {
            var entity = entityRepository.FindById(id);
            var resultEntity = Mapper.Map<LeaveDaysDto>(entity);

            return resultEntity;
        }

        public int CreateEntity(LeaveDaysDto newEntity, int? employeeId)
        {
            if (!employeeId.HasValue)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            LeaveDays leaveDaysToCreate = Mapper.Map<LeaveDays>(newEntity);
            leaveDaysToCreate.EmployeeID = employeeId.Value;
            LeaveDays createdEntity = entityRepository.Create(leaveDaysToCreate);
            entityRepository.SaveChanges();
            return createdEntity.Id;
        }


        public bool UpdateEntity(LeaveDaysDto newEntity)
        {
            LeaveDays leaveDaysToUpdate = Mapper.Map<LeaveDays>(newEntity);
            entityRepository.Update(leaveDaysToUpdate);
            bool updateResult = entityRepository.SaveChanges();
            return updateResult;
        }

        public bool DeleteEntityById(int id)
        {
            entityRepository.Delete(id);
            bool deleteResult = entityRepository.SaveChanges();
            return deleteResult;
        }

        public IEnumerable<LeaveDaysDto> GetAllForEmployee(int employeeId)
        {
            var employeeLeaveDays = entityRepository
                .FindAll()
                .Where(leaveDay => employeeId == leaveDay.EmployeeID)
                .ToList();
            var resultLeaveDaysDto = Mapper.Map<List<LeaveDaysDto>>(employeeLeaveDays);

            return resultLeaveDaysDto;
        }

        public LeaveDaysDto GetAllForEmployeeByYear(int employeeId, int year)
        {
            var employeeLeaveDays = entityRepository
                .FindAll()
                .Where(leaveDay => employeeId == leaveDay.EmployeeID && leaveDay.ForYear == year)
                .FirstOrDefault();

            var resultLeaveDaysDto = Mapper.Map<LeaveDaysDto>(employeeLeaveDays);

            return resultLeaveDaysDto;
        }
    }
}