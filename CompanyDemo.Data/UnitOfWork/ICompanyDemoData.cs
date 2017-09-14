namespace CompanyDemo.Data.UnitOfWork
{
    using CompanyDemo.Data.Repositories;
    using CompanyDemo.Models;
    public interface ICompanyDemoData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Chief> Chiefs { get; }

        IRepository<Director> Directors { get; }

        IRepository<ProjectManager> ProjectManagers { get; }

        IRepository<Project> Projects { get; }

        IRepository<Team> Teams { get; }

        IRepository<TeamLead> TeamLeads { get; }

        IRepository<Employee> Employees { get; }
    }
}
