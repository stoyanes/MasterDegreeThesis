using Server.Business.Dto;
using Server.Business.Interfaces;
using System.Web.Http;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("Holidays")]
    public class HolidayController : ApiController
    {
        IHolidayService holidayService;

        public HolidayController(IHolidayService holService)
        {
            holidayService = holService;
        }

        [HttpGet]
        [Route("ForYear")]
        public IHttpActionResult GetForYear(int year)
        {
            var holidays = holidayService.GetForYear(year);
            return Ok(holidays);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateOrUpdate(HolidayDto holiday)
        {
            if (holiday.Id == 0)
            {
                holidayService.CreateEntity(holiday);
            }
            else
            {
                holidayService.UpdateEntity(holiday);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool deleteResult = holidayService.DeleteEntityById(id);
            return Ok(deleteResult);
        }
    }
}
