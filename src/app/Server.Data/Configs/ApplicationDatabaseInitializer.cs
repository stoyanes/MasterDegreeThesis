using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Server.Data.Model;

namespace Server.Data.Configs
{
    public class ApplicationDatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<Employee, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));

            var adminUser = new Employee { Email = "admin@myemail.com", UserName = "admin@myemail.com" };
            manager.Create(adminUser, "Temp_123");
            //adminUser.Manager = adminUser;
            
            var employeeUser = new Employee { Email = "employee1@myemail.com", UserName = "employee1@myemail.com" };
            manager.Create(employeeUser, "Temp_123");
            employeeUser.Manager = adminUser;

            var managerUser = new Employee { Email = "managerUser@myemail.com", UserName = "managerUser@myemail.com" };
            manager.Create(managerUser, "Temp_123");

            var roleManager = new ApplicationRoleManager(new RoleStore<CustomRole, int, CustomUserRole>(context));
            roleManager.Create(new CustomRole("admin"));
            roleManager.Create(new CustomRole("regular"));

            manager.AddToRole(adminUser.Id, "admin");
            manager.AddToRole(employeeUser.Id, "regular");

            context.Holidays.Add(new Holiday(){ WorkingDate = new DateTime(2016, 6, 1), Description = "Worker's day."});
            context.Holidays.Add(new Holiday() { WorkingDate = new DateTime(2016, 6, 6), Description = "St. George's Day." });

            context.SaveChanges();
        }
    }
}
