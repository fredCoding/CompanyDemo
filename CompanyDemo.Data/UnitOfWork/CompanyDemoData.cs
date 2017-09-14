using System;
using System.Collections.Generic;
using CompanyDemo.Data.Repositories;
using CompanyDemo.Models;
using System.Data.Entity;

namespace CompanyDemo.Data.UnitOfWork
{
    public class CompanyDemoData : ICompanyDemoData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public CompanyDemoData()
            : this(new ApplicationDbContext())
        {
        }

        public CompanyDemoData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Chief> Chiefs
        {
            get
            {
                return this.GetRepository<Chief>();
            }
        }
        public IRepository<Director> Directors
        {
            get
            {
                return this.GetRepository<Director>();
            }
        }
        public IRepository<ProjectManager> ProjectManagers
        {
            get
            {
                return this.GetRepository<ProjectManager>();
            }
        }
        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepository<Project>();
            }
        }
        public IRepository<Team> Teams
        {
            get
            {
                return this.GetRepository<Team>();
            }
        }
        public IRepository<TeamLead> TeamLeads
        {
            get
            {
                return this.GetRepository<TeamLead>();
            }
        }
        public IRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }


        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
