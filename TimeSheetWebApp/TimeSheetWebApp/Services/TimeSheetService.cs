using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private ITimeSheetRepository _timeSheetRepository;
        private IUnitOfWork _unitOfWork;

        public TimeSheetService(ITimeSheetRepository timeSheetRepository, IUnitOfWork unitOfWork)
        {
            _timeSheetRepository = timeSheetRepository;
            _unitOfWork = unitOfWork;
        }

        public TimeSheet Delete(TimeSheet obj)
        {
            return _timeSheetRepository.Delete(obj);
        }

        public IEnumerable<TimeSheet> GetAll()
        {
            return _unitOfWork.TimeSheet.GetAll();
        }

        public List<TimeSheetDTO> GetAllForDate(DateTime date)
        {
            List<TimeSheetDTO> timesheets = new List<TimeSheetDTO>();
            foreach (TimeSheet timesheet in _timeSheetRepository.GetAll())
            {
                if (timesheet.Date.Year.Equals(date.Year) && timesheet.Date.Month.Equals(date.Month) && timesheet.Date.Day.Equals(date.Day))
                {
                    timesheet.Category = _unitOfWork.Category.GetOneById(timesheet.CategoryId);
                    timesheet.Project = _unitOfWork.Project.GetOneById(timesheet.ProjectId);
                    timesheet.Project.Client = _unitOfWork.Clients.GetOneById(timesheet.Project.ClientId);
                    timesheet.Employee = _unitOfWork.Employee.GetOneById(timesheet.EmployeeId);
                    timesheets.Add(new TimeSheetDTO(timesheet));
                }
            }
            return timesheets;
        }

        public TimeSheet GetOneById(int id)
        {
            return _timeSheetRepository.GetOneById(id);
        }

        public TimeSheet Save(TimeSheet obj)
        {
            return _timeSheetRepository.Save(obj);
        }

        public TimeSheet Update(TimeSheet obj)
        {
            return _unitOfWork.TimeSheet.Update(obj);
        }

        public List<CalendarItemDto> GetCalendarItems(DateTime date, int employeeId)
        {
            List<DateTime> dates = GetAllDates(date);

            List<CalendarItemDto> calendarItemDtos = GetCreatedCalendarItems(dates, employeeId);

            return CreateMonthlyCalendarItems(dates, calendarItemDtos);
        }
        private List<DateTime> GetAllDates(DateTime date)
        {
            List<DateTime> datesInThisMonth = GetDatesInThisMonth(date.Month, date.Year);
            int dayOfWeek = datesInThisMonth.FirstOrDefault().DayOfWeek == 0
                ? 7 : (int)datesInThisMonth.FirstOrDefault().DayOfWeek - 1;
            List<DateTime> datesFromLastMonth = GetDatesFromLastMonth(dayOfWeek, date.Month, date.Year);

            int numberOfFutureDates = 42 - datesInThisMonth.Count - datesFromLastMonth.Count;
            List<DateTime> datesFromNextMonth = GetDatesFromNextMonth(numberOfFutureDates, date.Month, date.Year);

            return datesFromLastMonth.Concat(datesInThisMonth).Concat(datesFromNextMonth).ToList();
        }

        private List<DateTime> GetDatesInThisMonth(int month, int year)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => new DateTime(year, month, day))
                             .ToList();
        }

        private List<DateTime> GetDatesFromLastMonth(int numberOfDays, int month, int year)
        {
            return Enumerable.Range(1, numberOfDays)
                            .Select(day => new DateTime(year, month, 1).AddDays(-day)).Reverse()
                            .ToList();
        }

        private List<DateTime> GetDatesFromNextMonth(int numberOfDays, int month, int year)
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            return Enumerable.Range(1, numberOfDays)
                             .Select(day => new DateTime(year, month, day)).ToList();
        }

        private List<CalendarItemDto> GetCreatedCalendarItems(List<DateTime> dates, int employeeId)
        {
            return   GetAllBetweenDates(dates.FirstOrDefault(), dates.LastOrDefault(), employeeId)
                    .GroupBy(DailyTimeSheet => DailyTimeSheet.Date)
                    .Select(calendarItemDto => new CalendarItemDto
                    {
                        Date = calendarItemDto.First().Date,
                        TotalHours = calendarItemDto.Sum(c => c.Time + c.Overtime),
                    }).ToList();
        }

        private List<CalendarItemDto> CreateMonthlyCalendarItems(List<DateTime> dates, List<CalendarItemDto> calendarItemDtos)
        {
            return dates.Select(dateTime => calendarItemDtos
            .Any(calendarItem => calendarItem.Date.Date == dateTime.Date) ?
            calendarItemDtos.FirstOrDefault(calendarItem => calendarItem.Date.Date == dateTime.Date) :
            new CalendarItemDto
            {
                Date = dateTime,
                TotalHours = 0
            }).ToList();
        }

        private List<TimeSheet> GetAllBetweenDates(DateTime fromDate, DateTime toDate, int employeeId)
        {
            List<TimeSheet> timesheets = new List<TimeSheet>(); 
            foreach(TimeSheet timesheet in _timeSheetRepository.GetAll())
            {
                if(timesheet.Date>fromDate && timesheet.Date<toDate && timesheet.EmployeeId.Equals(employeeId))
                {
                    timesheets.Add(timesheet);
                }
            }
            return timesheets;
        }
    }
}
