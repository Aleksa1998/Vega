using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        AppDbContext dbContext;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            dbContext = context;
        }

        public Employee GetByLoginInfo(UserModel login)
        {
            return dbContext.Employees.SingleOrDefault(employee => employee.Username.Equals(login.Username) && employee.Password.Equals(login.Password) && !employee.IsDeleted);
        }

        public Employee GetOne(int? id)
        {
            return dbContext.Employees.SingleOrDefault(employee => employee.Id.Equals(id));
        }
    }
}
