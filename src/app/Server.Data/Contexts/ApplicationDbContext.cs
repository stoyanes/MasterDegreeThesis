using Microsoft.AspNet.Identity.EntityFramework;
using Server.Data.Model;
using System.Data.Entity;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        #region Constructors
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        #endregion


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<CustomUserRole>().ToTable("EmployeeRole");
            modelBuilder.Entity<CustomUserLogin>().ToTable("EmployeeLogin");
            modelBuilder.Entity<CustomUserClaim>().ToTable("EmployeeClaim");
            modelBuilder.Entity<CustomRole>().ToTable("Role");

            modelBuilder.Entity<Employee>().HasOptional(e => e.Manager).WithMany().HasForeignKey(m => m.ManagerID);
        }

        public DbSet<LeaveDays> LeaveDays { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<VacationRequest> Requests { get; set; }

        public DbSet<AdditionalWorkingDay> AdditionalWorkingDays{ get; set; }
    }
}
