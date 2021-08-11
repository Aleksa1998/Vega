using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Interface.Service
{
    public interface ITimeSheetService : IService<TimeSheet>
    {
        List<CalendarItemDto> GetCalendarItems(DateTime date, int employeeId);
        List<TimeSheetDTO> GetAllForDate(DateTime date);
    }
}
