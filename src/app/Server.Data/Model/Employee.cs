using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Data.Model
{
    public class Employee : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Employee()
        {

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

        public virtual IEnumerable<Request> Requests { get; set; }

        public virtual IEnumerable<LeaveDays> LeaveDays { get; set; }

        public int? ManagerID { get; set; }
        public virtual Employee Manager { get; set; }

        public bool IsEmployeeActive { get; set; }
    }

}