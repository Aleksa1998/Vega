using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class TimeSheetDTO
    {
        public TimeSheetDTO()
        {
        }

        public TimeSheetDTO(TimeSheet timeSheet)
        {
            Id = timeSheet.Id;
            Date = timeSheet.Date;
            Time = timeSheet.Time;
            Overtime = timeSheet.Overtime;
            Description = timeSheet.Description;
            Employee = new EmployeeDTO(timeSheet.Employee);
            Category = new CategoryDTO(timeSheet.Category);
            Project = new ProjectShowDTO(timeSheet.Project);
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float Overtime { get; set; }
        public string Description { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryDTO Category { get; set; }
        public ProjectShowDTO Project { get; set; }
    }
}
