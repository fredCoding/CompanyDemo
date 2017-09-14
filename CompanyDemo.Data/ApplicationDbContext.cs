namespace CompanyDemo.Data
{
    using CompanyDemo.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamLead> TeamLeads { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectManager> ProjectManangers { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Chief> Chiefs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
