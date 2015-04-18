using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Data.Model;
using Server.Data.Repositories;
using Microsoft.AspNet.Identity;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/LeaveDays")]
    public class LeaveDaysController : ApiController
    {
        private IRepository<LeaveDays> leaveDaysRepository = new Repository<LeaveDays>();

        [Authorize(Roles="admin, hr")]
        [Route("GetAll")]
        public IEnumerable<LeaveDays> GetAll()
        {
            var allLeaveDays = leaveDaysRepository
                                .FindAll()
                                .ToList();

            return allLeaveDays;
        }

        [Route("GetForEmployee")]
        public IEnumerable<LeaveDays> GetForEmployee()
        {
            var currentEmployeeId = User.Identity.GetUserId();

            var employeeLeaveDays = leaveDaysRepository
                                 .FindAll()
                                 .Where(leaveDay => currentEmployeeId == leaveDay.EmployeeID)
                                 .ToList();

            return employeeLeaveDays;
        } 
    }
}
