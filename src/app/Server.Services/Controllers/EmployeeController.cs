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
        private IRepository<Employee> employeesRepository = new Repository<Employee>(new ApplicationDbContext());

        // DI for later unit testing
        public EmployeeController(IRepository<Employee> employeesRepo)
        {
            this.employeesRepository = employeesRepo;
        }

        [HttpGet]
        //[Authorize(Roles="admin, hr")]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var employees = employeesRepository.FindAll().ToList();
            return Ok(employees);
        }

        [HttpGet]
        //[Authorize(Roles="admin, hr")]
        [Route("{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            Employee employee = employeesRepository.FindById(id);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        //[Authorize(Roles="admin, hr")]
        [Route("Active")]
        public IHttpActionResult GetAllActive()
        {
            var employees = employeesRepository
                .FindAll()
                .Where(employee => employee.IsEmployeeActive == true)
                .ToList();
            return Ok(employees);
        }
        
        [HttpPost]
        //[Authorize(Roles="admin, hr")]
        [Route("")]
        public IHttpActionResult CreateEmployee([FromBody] Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee createdEmplyee = employeesRepository.Create(newEmployee);
                string createdEmplyeLocation = string.Format("{0}/{1}", Request.RequestUri.ToString(), newEmployee.Id);
                return Created(createdEmplyeLocation, createdEmplyee);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        //[Authorize(Roles="admin, hr")]
        [Route("{id}")]
        public IHttpActionResult UpdateEmployee([FromBody] Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                employeesRepository.Update(newEmployee);
                employeesRepository.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        //[Authorize(Roles="admin, hr")]
        [Route("{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            employeesRepository.Delete(id);
            bool deleteResult = employeesRepository.SaveChanges();
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                // TODO some better error here?
                return NotFound();
            }
        }
    }
}
