using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSheetController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ITimeSheetService _timeSheetService;
        public TimeSheetController(IUnitOfWork unitOfWork, ITimeSheetService timeSheetService)
        {
            _unitOfWork = unitOfWork;
            _timeSheetService = timeSheetService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_timeSheetService.GetAll());
        }

        [HttpPost("calendar")]
        public IActionResult GetAllMonthly(ShowTimeSheetDTO dto)
        {
            return Ok(_timeSheetService.GetCalendarItems(dto.Date, dto.EmployeeId));
        }

        [HttpPost("date")]
        public IActionResult GetAllForDate(DateDTO date)
        {
            return Ok(_timeSheetService.GetAllForDate(date.Date));
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            TimeSheet timeSheet = _unitOfWork.TimeSheet.GetOneById(id);
            return (timeSheet == null) ? NotFound() : Ok(timeSheet);
        }

        [HttpPost]
        public IActionResult Save(TimeSheet timeSheet)
        {
            return Ok(_unitOfWork.TimeSheet.Save(timeSheet));
        }

        [HttpPost("update")]
        public IActionResult Update(TimeSheet timeSheet)
        {
            return Ok(_unitOfWork.TimeSheet.Update(timeSheet));
        }

        [HttpPost("delete")]
        public IActionResult Delete(TimeSheet timeSheet)
        {
            return Ok(_unitOfWork.TimeSheet.Delete(timeSheet));
        }
    }
}
