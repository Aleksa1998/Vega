using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;

namespace TimeSheetWebApp
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        ICategoryRepository Category { get; }
        ICountryRepository Country { get; }
        IProjectRepository Project { get; }
        IEmployeeRepository Employee { get; }
        ITimeSheetRepository TimeSheet { get; }
        int Complete();
    }
}
