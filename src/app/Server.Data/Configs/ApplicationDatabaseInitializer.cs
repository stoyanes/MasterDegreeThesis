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

            var employeeUser = new Employee { Email = "employee1@myemail.com", UserName = "employee1@myemail.com" };
            manager.Create(employeeUser, "Temp_123");

            var managerUser = new Employee { Email = "managerUser@myemail.com", UserName = "managerUser@myemail.com" };
            manager.Create(managerUser, "Temp_123");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("employee"));

            manager.AddToRole(adminUser.Id, "admin");
            manager.AddToRole(employeeUser.Id, "employee");

            context.Holidays.Add(new Holiday(){ ForYear = 2015, HolidayDate = new DateTime(2015, 6, 1) });
            context.Holidays.Add(new Holiday() { ForYear = 2015, HolidayDate = new DateTime(2015, 6, 6) });

            context.SaveChanges();
        }
    }
}
