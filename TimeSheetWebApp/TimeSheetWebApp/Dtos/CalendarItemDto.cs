using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Dtos
{
    public class CalendarItemDto
    {
        public CalendarItemDto()
        {
        }
        public CalendarItemDto(DateTime date, float totalHours)
        {
            Date = date;
            TotalHours = totalHours;
        }
        public DateTime Date { get; set; }
        public float TotalHours { get; set; }
    }
}
