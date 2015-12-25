using System.Web.Http;
using Server.Business.Interfaces;
using Server.Business.Services;
using Server.Business.Dto;
using Microsoft.AspNet.Identity;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("VacationRequests")]
    public class VacationRequestController : ApiController
    {
        IVacationRequestService vacationRequestService = new VacationRequestService();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var entities = vacationRequestService.GetAll();
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int entityId)
        {
            var entity = vacationRequestService.GetById(entityId);
            return Ok(entity);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEntity([FromBody] VacationRequestDto newEntity)
        {
            int employeeId = this.User.Identity.GetUserId<int>();
            int createdId = vacationRequestService.CreateEntity(employeeId, newEntity);
            return Ok(createdId);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateEntity([FromBody] VacationRequestDto newEntity)
        {
            vacationRequestService.UpdateEntity(newEntity);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEntity(int id)
        {
            bool deleteResult = vacationRequestService.DeleteEntityById(id);
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
