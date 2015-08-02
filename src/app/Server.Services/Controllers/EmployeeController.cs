using System.Linq;
using System.Web.Http;
using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Employees")]
    public class EmployeeController : ApiController
    {
        private IRepository<Employee> employeeRepository = new Repository<Employee>(new ApplicationDbContext());

        //[Authorize(Roles="admin, hr")]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var employees = employeeRepository.FindAll().ToList<Employee>();
            return Ok(employees);
        }

        [Authorize(Roles="admin, hr")]
        [Route("GetAllActive")]
        public IHttpActionResult GetAllActive()
        {
            var employees = employeeRepository
                .FindAll()
                .Where(employee => employee.IsEmployeeActive == true)
                .ToList<Employee>();
            return Ok(employees);
        }
    }
}
