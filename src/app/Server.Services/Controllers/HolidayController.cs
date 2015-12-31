using Server.Business.Dto;
using Server.Business.Interfaces;
using Server.Business.Services;
using Server.Data.Model;
using System.Linq;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("Holidays")]
    public class HolidayController : ApiController
    {

        IHolidayService holidayService = new HolidayService();

        [HttpGet]
        [Route("ForYear")]
        public IHttpActionResult GetForYear(int year)
        {
            var holidays = holidayService.GetForYear(year);

            return Ok(holidays);
        }
    }
}
