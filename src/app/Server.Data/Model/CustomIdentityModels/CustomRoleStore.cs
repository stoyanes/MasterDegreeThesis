using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Data.Model.CustomIdentityModels
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
