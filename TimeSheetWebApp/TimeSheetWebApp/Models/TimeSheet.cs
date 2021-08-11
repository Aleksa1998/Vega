using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class TimeSheet
    {
        public TimeSheet()
        {
        }
        public TimeSheet(int id, DateTime date, float time, float overtime, string descriotion, int categoryId, int employeeId, int projectId)
        {
            Id = id;
            Date = date;
            Time = time;
            Overtime = overtime;
            Description = descriotion;
            CategoryId = categoryId;
            EmployeeId = employeeId;
            ProjectId = projectId;
        } 
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float Overtime { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public bool IsDeleted { get; set; }
    }
}
