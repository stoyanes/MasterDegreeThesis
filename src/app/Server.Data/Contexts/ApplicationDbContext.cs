using Microsoft.AspNet.Identity.EntityFramework;
using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<IdentityUserRole>().ToTable("EmployeeRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("EmployeeLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("EmployeeClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
        }
    }
}
