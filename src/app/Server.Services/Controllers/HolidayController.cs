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
    [Authorize]
    [RoutePrefix("api/holidays")]
    public class HolidayController : ApiController
    {
        private IRepository<Holiday> holidayRepository = new Repository<Holiday>(new ApplicationDbContext());

        [Route("GetAll")]
        public IEnumerable<Holiday> GetAll()
        {
            var holidays = holidayRepository.FindAll().ToList<Holiday>();
            return holidays;
        }

        [Route("GetAllForYear")]
        public IEnumerable<Holiday> GetAllForYear(int year)
        {
            var holidays = holidayRepository.FindAll()
                .Where(holiday =>  holiday.ForYear == year)
                .ToList();

            return holidays;
        }
    }
}
