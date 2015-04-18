using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/Employees")]
    public class EmployeeController : ApiController
    {
        private IRepository<Employee> employeeRepository = new Repository<Employee>(new ApplicationDbContext());

        [Authorize(Roles="admin, hr")]
        [Route("GetAll")]
        public IEnumerable<Employee> GetAll()
        {
            var employees = employeeRepository.FindAll().ToList<Employee>();
            return employees;
        }

        [Authorize(Roles="admin, hr")]
        [Route("GetAllActive")]
        public IEnumerable<Employee> GetAllActive()
        {
            var employees = employeeRepository
                .FindAll()
                .Where(employee => employee.IsEmployeeActive == true)
                .ToList<Employee>();
            return employees;
        }
    }
}
