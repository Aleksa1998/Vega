using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Dtos
{
    public class ShowTimeSheetDTO
    {
        public ShowTimeSheetDTO()
        {
        }
        public ShowTimeSheetDTO(DateTime date, int employeeId)
        {
            Date = date;
            EmployeeId = employeeId;
        }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
    }
}
