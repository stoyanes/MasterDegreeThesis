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
    [AllowAnonymous]
    [RoutePrefix("api/Holidays")]
    public class HolidayController : ApiController
    {

        private IRepository<Holiday> employeeRepository = new Repository<Holiday>(new ApplicationDbContext());

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Holiday> GetAll()
        {
            var employees = employeeRepository.FindAll().ToList<Holiday>();
            return employees;
        }
    }
}
