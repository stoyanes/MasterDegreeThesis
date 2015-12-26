using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;

namespace Server.Business.Services
{
    public class LeaveDaysService : BaseBusinessService<LeaveDays, LeaveDaysDto>, ILeaveDaysService
    {
        public override int CreateEntity(LeaveDaysDto newEntity, int? employeeId)
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