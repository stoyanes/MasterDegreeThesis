using System.Web.Http;
using Microsoft.AspNet.Identity;
using Server.Business.Interfaces;
using Server.Business.Services;
using Server.Business.Dto;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("LeaveDays")]
    public class LeaveDaysController : ApiController
    {
        ILeaveDaysService leaveDaysService = new LeaveDaysService();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var entities = leaveDaysService.GetAll();
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int entityId)
        {
            var entity = leaveDaysService.GetById(entityId);

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
        public virtual IHttpActionResult CreateEntity([FromBody] LeaveDaysDto newEntity)
        {
            var currentEmployeeId = this.User.Identity.GetUserId<int>();
            var createdEntityId = leaveDaysService.CreateEntity(newEntity, currentEmployeeId);
            return Ok(createdEntityId);
        }

        [HttpPut]
        [Route("")]
        public virtual IHttpActionResult UpdateEntity([FromBody] LeaveDaysDto newEntity)
        {
            var updateResult = leaveDaysService.UpdateEntity(newEntity);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IHttpActionResult DeleteEntity(int id)
        {
            var deleteResult = leaveDaysService.DeleteEntityById(id);
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("AllForEmployee")]
        public IHttpActionResult GetAllForEmployee()
        {
            var currentEmployeeId = this.User.Identity.GetUserId<int>();

            var employeeLeaveDays = leaveDaysService.GetAllForEmployee(currentEmployeeId);

            return Ok(employeeLeaveDays);
        }

        [HttpGet]
        [Route("AllForEmployeeByYear/{year}")]
        public IHttpActionResult GetAllForEmployeeByYear(int year)
        {
            var currentEmployeeId = this.User.Identity.GetUserId<int>();
            var employeeLeaveDays = leaveDaysService.GetAllForEmployeeByYear(currentEmployeeId, year);

            return Ok(employeeLeaveDays);
        }
    }
}
