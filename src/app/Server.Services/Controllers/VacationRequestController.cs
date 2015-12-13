using Server.Data.Model;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("VacationRequests")]
    public class VacationRequestController : BaseController<VacationRequest>
    {
        public override IHttpActionResult CreateEntity([FromBody] VacationRequest newEntity)
        {
            if (ModelState.IsValid)
            {
                newEntity.EmployeeID = this.User.Identity.GetUserId<int>();
                newEntity.CreatedDate = DateTime.Now;
                newEntity.Status = Data.RequestStates.Submitted;

                VacationRequest createdRequest = entityRepository.Create(newEntity);
                entityRepository.SaveChanges();

                string createdLocation = string.Format("{0}/{1}", Request.RequestUri.ToString(), "");
                return Created(createdLocation, createdRequest);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
