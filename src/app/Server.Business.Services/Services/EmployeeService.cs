using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Data.Model;
using System.Linq;
using AutoMapper;

namespace Server.Business.Services
{
    public class EmployeeService : BaseBusinessService<Employee, EmployeeDto>, IEmployeeService
    {
        public bool UpdateLeaveDaysForYear(int employeeId, int year, LeaveDaysDto leaveDays)
        {
            var employee = this.entityRepository
                               .FindById(employeeId);

            if (employee == null)
            {
                return false;
            }

            var empLeaveDays = employee.LeaveDays
                .Where(leaveDay => leaveDay.ForYear == year)
                .FirstOrDefault();

            empLeaveDays = Mapper.Map<LeaveDays>(leaveDays);
            entityRepository.SaveChanges();

            return true;
        }

        public override bool UpdateEntity(EmployeeDto newEntity)
        {
            Employee empToUpdate = this.entityRepository.FindById(newEntity.Id);
            Employee newManager = null;

            if (newEntity.Manager != null)
            {
                newManager = this.entityRepository.FindById(newEntity.Manager.Id);
            }

            if (empToUpdate != null)
            {
                empToUpdate.Manager = newManager;
                empToUpdate.UserName = newEntity.UserName;

                return this.entityRepository.SaveChanges();
            }
            else
            {
                return false;
            }
        }

        public override bool DeleteEntityById(int id)
        {
            Employee empToDelete = this.entityRepository.FindById(id);
            if (empToDelete.Manager != null)
            {
                empToDelete.Manager = null;
                this.entityRepository.Update(empToDelete);
                this.entityRepository.SaveChanges();
            }
            this.entityRepository.Delete(id);
            return this.entityRepository.SaveChanges();
        }
    }
}
