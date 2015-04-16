using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Server.Data.Model;

namespace Server.Data.Configs
{
    public class ApplicationDatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<Employee>(context));

            var adminUser = new Employee { Email = "admin@myemail.com", UserName = "admin@myemail.com" };
            manager.Create(adminUser, "Temp_123");

            var regularUser = new Employee { Email = "regular@myemail.com", UserName = "regular@myemail.com" };
            manager.Create(regularUser, "Temp_123");

            var HRUser = new Employee { Email = "HRUser@myemail.com", UserName = "HRUser@myemail.com" };
            manager.Create(HRUser, "Temp_123");
            
            var managerUser = new Employee { Email = "managerUser@myemail.com", UserName = "managerUser@myemail.com" };
            manager.Create(managerUser, "Temp_123");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("employee"));
            roleManager.Create(new IdentityRole("hr"));
            roleManager.Create(new IdentityRole("manager"));

            manager.AddToRole(adminUser.Id, "admin");
            manager.AddToRole(regularUser.Id, "employee");
            manager.AddToRole(HRUser.Id, "hr");
            manager.AddToRole(managerUser.Id, "manager");

            context.Holidays.Add(new Holiday(){ ForYear = 2015, HolidayDate = new DateTime(2015, 6, 1) });
            context.Holidays.Add(new Holiday() { ForYear = 2015, HolidayDate = new DateTime(2015, 6, 6) });

            context.SaveChanges();
        }
    }
}
