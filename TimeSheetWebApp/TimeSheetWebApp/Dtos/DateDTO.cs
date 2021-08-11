using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Dtos
{
    public class DateDTO
    {
        public DateDTO()
        {
        }
        public DateDTO(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; set; }
    }
}
