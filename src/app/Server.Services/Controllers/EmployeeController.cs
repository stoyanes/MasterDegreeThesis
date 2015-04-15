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
    [AllowAnonymous]
    [RoutePrefix("api/Test")]
    public class EmployeeController : ApiController
    {
        private IRepository<Employee> employeeRepository = new Repository<Employee>(new ApplicationDbContext());

        [AllowAnonymous]
        [Route("GetAll")]
        public IEnumerable<Employee> GetAll()
        {
            var employees = employeeRepository.FindAll().ToList<Employee>();
            return employees;
        }
    }
}
