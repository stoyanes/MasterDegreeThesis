using System.Web.Http;
using Server.Data.Model;
using Server.Business.Interfaces;
using Server.Business.Dto;
using Server.Business.Services;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Employees")]
    public class EmployeeController : ApiController
    {
        IBaseBusinessService<EmployeeDto> employeeService = new BaseBusinessService<Employee, EmployeeDto>();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var entities = employeeService.GetAll();
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int entityId)
        {
            EmployeeDto entity = employeeService.GetById(entityId);

            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEntity([FromBody] EmployeeDto newEntity)
        {
            var createResult = employeeService.CreateEntity(newEntity);
            return Ok(createResult);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateEntity([FromBody] EmployeeDto newEntity)
        {
            bool updateResult = employeeService.UpdateEntity(newEntity);
            if (updateResult)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEntity(int id)
        {
            bool deleteResult = employeeService.DeleteEntityById(id);
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();

            }
        }
    }
}
