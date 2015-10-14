
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Data.Model
{
    public class CustomUserStore : UserStore<Employee, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
