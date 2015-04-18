using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Data.Model
{
    public class Employee : IdentityUser
    {
        public Employee()
        {

        }

        #region Public methods
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion

        public virtual IEnumerable<Request> Requests { get; set; }

        public virtual IEnumerable<LeaveDays> LeaveDays { get; set; }

        public bool IsEmployeeActive { get; set; }
    }

}