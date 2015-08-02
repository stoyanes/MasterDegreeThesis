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

        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var holidays = holidayRepository.FindAll().ToList<Holiday>();
            return Ok(holidays);
        }

        [Route("GetAllForYear")]
        public IHttpActionResult GetAllForYear(int year)
        {
            var holidays = holidayRepository.FindAll()
                .Where(holiday =>  holiday.ForYear == year)
                .ToList();

            return Ok(holidays);
        }
    }
}
