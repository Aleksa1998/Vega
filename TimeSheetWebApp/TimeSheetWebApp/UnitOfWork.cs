using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IClientRepository Clients { get; }
        public ICategoryRepository Category { get; }
        public ICountryRepository Country { get; }
        public IProjectRepository Project { get; }
        public IEmployeeRepository Employee { get; }
        public ITimeSheetRepository TimeSheet { get; }
        public UnitOfWork(AppDbContext appDbContext,
           IClientRepository clientRepository, ICategoryRepository categoryRepository, ICountryRepository countryRepository, IProjectRepository projectRepository,
            IEmployeeRepository employeeRepository, ITimeSheetRepository timeSheetRepository)
        {
            context = appDbContext;
            Clients = clientRepository;
            Category = categoryRepository;
            Country = countryRepository;
            Project = projectRepository;
            Employee = employeeRepository;
            TimeSheet = timeSheetRepository;
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
