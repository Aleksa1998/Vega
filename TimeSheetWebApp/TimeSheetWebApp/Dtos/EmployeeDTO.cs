using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
        }
        public EmployeeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public EmployeeDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
