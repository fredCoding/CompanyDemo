namespace CompanyDemo.Data.UnitOfWork
{
    using CompanyDemo.Data.Repositories;
    using CompanyDemo.Models;
    public interface ICompanyDemoData
    {
        IRepository<ApplicationUser> Users { get; }
    }
}
