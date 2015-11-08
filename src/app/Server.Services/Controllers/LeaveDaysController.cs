using System.Linq;
using System.Web.Http;
using Server.Data.Model;
using Server.Data.Repositories;
using Microsoft.AspNet.Identity;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("LeaveDays")]
    public class LeaveDaysController : ApiController
    {
        private IRepository<LeaveDays> leaveDaysRepository = new Repository<LeaveDays>();

        // DI for later unit testing
        public LeaveDaysController(IRepository<LeaveDays> leaveDaysRepo)
        {
            this.leaveDaysRepository = leaveDaysRepo;
        }

        [Authorize(Roles="admin, hr")]
        [HttpGet]
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var allLeaveDays = leaveDaysRepository
                                .FindAll()
                                .ToList();

            return Ok(allLeaveDays);
        }

        [HttpGet]
        [Route("AllForEmployee")]
        public IHttpActionResult GetAllForEmployee()
        {
            var currentEmployeeId = User.Identity.GetUserId<int>();

            var employeeLeaveDays = leaveDaysRepository
                                 .FindAll()
                                 .Where(leaveDay => currentEmployeeId == leaveDay.EmployeeID)
                                 .ToList();

            return Ok(employeeLeaveDays);
        } 

        [HttpGet]
        [Route("AllForEmployeeByYear")]
        public IHttpActionResult GetAllForEmployeeByYear(int year)
        {
            var currentEmployeeId = User.Identity.GetUserId<int>();

            var employeeLeaveDays = leaveDaysRepository
                                 .FindAll()
                                 .Where(leaveDay => currentEmployeeId == leaveDay.EmployeeID && leaveDay.ForYear == year)
                                 .ToList();

            return Ok(employeeLeaveDays);
        } 
    }
}
