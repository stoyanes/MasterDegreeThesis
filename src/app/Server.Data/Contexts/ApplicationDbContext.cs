using Microsoft.AspNet.Identity.EntityFramework;
using Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        #region Constructors
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        #endregion


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


            modelBuilder.Entity<Employee>().HasOptional(e => e.Manager).WithMany().HasForeignKey(m => m.ManagerID);
        }

        public DbSet<LeaveDays> LeaveDays { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Request> Requests { get; set; }

    }
}
