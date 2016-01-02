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
    }
}
