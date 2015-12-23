using System.Linq;
using System.Web.Http;
using Server.Data.Model;
using Microsoft.AspNet.Identity;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("LeaveDays")]
    public class LeaveDaysController : BaseController<LeaveDays>
    {
        [HttpGet]
        [Route("AllForEmployee")]
        public IHttpActionResult GetAllForEmployee()
        {
            var currentEmployeeId = this.User.Identity.GetUserId<int>();

            var employeeLeaveDays = entityRepository
                .FindAll()
                .Where(leaveDay => currentEmployeeId == leaveDay.EmployeeID)
                .ToList();

            return Ok(employeeLeaveDays);
        } 

        [HttpGet]
        [Route("AllForEmployeeByYear")]
        public IHttpActionResult GetAllForEmployeeByYear(int year)
        {
            var currentEmployeeId = this.User.Identity.GetUserId<int>();
            // TODO add where expression to FindAll method
            var employeeLeaveDays = entityRepository
                .FindAll()
                .Where(leaveDay => currentEmployeeId == leaveDay.EmployeeID && leaveDay.ForYear == year)
                .ToList();

            return Ok(employeeLeaveDays);
        } 
    }
}
