using Server.Data.Model;
using System.Linq;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Holidays")]
    public class HolidayController : BaseController<Holiday>
    {
        [HttpGet]
        [Route("ForYear")]
        public IHttpActionResult GetForYear(int year)
        {
            var holidays = this.entityRepository
                .FindAll()
                .Where(holiday => holiday.ForYear == year)
                .ToList();

            return Ok(holidays);
        }
    }
}
