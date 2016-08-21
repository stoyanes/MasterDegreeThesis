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
        IVacationRequestService vacationRequestService; // = new VacationRequestService();

        public VacationRequestController(IVacationRequestService vacationReqService)
        {
            vacationRequestService = vacationReqService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var entities = vacationRequestService.GetAll();

            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpGet]
        [Route("GetAllForCurrentUser")]
        public IHttpActionResult GetAllForCurrentUser()
        {
            int employeeId = this.User.Identity.GetUserId<int>();
            var entities = vacationRequestService.GetAllForEmployee(employeeId);

            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int entityId)
        {
            var entity = vacationRequestService.GetById(entityId);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEntity([FromBody] VacationRequestDto newEntity)
        {
            int employeeId = this.User.Identity.GetUserId<int>();
            newEntity.EmployeeID = this.User.Identity.GetUserId<int>();
            int createdId = vacationRequestService.CreateEntity(newEntity);
            return Ok(createdId);
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult UpdateEntity([FromBody] VacationRequestDto newEntity)
        {
            bool updateResult = vacationRequestService.UpdateEntity(newEntity);
            if (updateResult)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult DeleteEntity(int id)
        {
            bool deleteResult = vacationRequestService.DeleteEntityById(id);
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("GetRequestsToApprove")]
        public IHttpActionResult GetRequestsToApprove()
        {
            int employeeId = this.User.Identity.GetUserId<int>();
            var vaqReqToApprove = this.vacationRequestService.GetRequestsToApprove(employeeId);
            return Ok(vaqReqToApprove);
        }
    }
}
