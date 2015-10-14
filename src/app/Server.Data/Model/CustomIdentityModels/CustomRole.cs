
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Data.Model
{
    public class CustomRole: IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
