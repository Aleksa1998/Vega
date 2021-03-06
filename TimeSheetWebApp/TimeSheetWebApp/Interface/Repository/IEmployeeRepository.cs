using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Interface.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetByLoginInfo(UserModel login);
    }
}
