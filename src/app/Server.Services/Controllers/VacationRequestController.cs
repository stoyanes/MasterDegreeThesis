using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("VacationRequests")]
    public class VacationRequestController : ApiController
    {
        private IRepository<VacationRequest> vacationRequestRepository = new Repository<VacationRequest>(new ApplicationDbContext());

        // DI for unit testng
        public VacationRequestController(IRepository<VacationRequest> vacationReqReposotory)
        {
            this.vacationRequestRepository = vacationReqReposotory;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var vacationReqs = vacationRequestRepository.FindAll().ToList();
            return Ok(vacationReqs);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var vacationReq = vacationRequestRepository.FindById(id);

            if (vacationReq != null)
            {
                return Ok(vacationReq);
            }

            return NotFound();
        }

        
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateVacationRequest([FromBody] VacationRequest newVacationRequest)
        {
            if (ModelState.IsValid)
            {

                VacationRequest createdVacationRequest = vacationRequestRepository.Create(newVacationRequest);
                var createdLocation = string.Format("{0}/{1}", Request.RequestUri.ToString(), createdVacationRequest.ID);
                return Created(createdLocation, createdVacationRequest);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
