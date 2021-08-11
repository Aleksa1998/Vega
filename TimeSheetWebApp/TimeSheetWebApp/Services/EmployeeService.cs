using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee Delete(Employee obj)
        {
            return _employeeRepository.Delete(obj);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetOneById(int id)
        {
            return _employeeRepository.GetOneById(id);
        }

        public Employee Save(Employee obj)
        {
            return _employeeRepository.Save(obj);
        }

        public Employee Update(Employee obj)
        {
            return _employeeRepository.Update(obj);
        }
    }
}
