using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Server.Data.Model
{
    public class Employee : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Employee()
        {
            LeaveDays = new List<LeaveDays>();
            LeaveDays.Add(new LeaveDays() { AllowedNonPaidDays = 60, EmployeeID = this.Id, AllowedPaidDays = 20, ForYear = DateTime.Now.Year });
        }

        #region Public methods
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion

        public virtual IList<VacationRequest> Requests { get; set; }

        public virtual IList<LeaveDays> LeaveDays { get; set; }

        public int? ManagerID { get; set; }

        public virtual Employee Manager { get; set; }
    }
}
