using Server.Data;
using Server.Data.Model;
using Server.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Holidays")]
    public class HolidayController : ApiController
    {
        private IRepository<Holiday> holidayRepository = new Repository<Holiday>(new ApplicationDbContext());

        // DI for unit testng
        public HolidayController(IRepository<Holiday> holidayRepo)
        {
            this.holidayRepository = holidayRepo; 
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var holidays = holidayRepository.FindAll().ToList<Holiday>();
            return Ok(holidays);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Holiday holiday = holidayRepository.FindById(id);

            if (holiday != null)
            {
                return Ok(holiday);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("ForYear")]
        public IHttpActionResult GetForYear(int year)
        {
            var holidays = holidayRepository.FindAll()
                .Where(holiday => holiday.ForYear == year)
                .ToList();

            return Ok(holidays);
        }

        [HttpPost]
        [Route("Holiday")]
        public IHttpActionResult CreateHoliday([FromBody]Holiday newHoliday)
        {
            if (ModelState.IsValid)
            {
                Holiday createdHoliday = holidayRepository.Create(newHoliday);
                holidayRepository.SaveChanges();

                string locationCreated = string.Format("{0}/{1}", Request.RequestUri.ToString(), createdHoliday.ID);
                return Created(locationCreated, createdHoliday);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateHoliday([FromBody] Holiday newHoliday)
        {
            if (ModelState.IsValid)
            {
                holidayRepository.Update(newHoliday);
                holidayRepository.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteHoliday(int id)
        {
            holidayRepository.Delete(id);
            var deleteResult = holidayRepository.SaveChanges();

            if (deleteResult)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
