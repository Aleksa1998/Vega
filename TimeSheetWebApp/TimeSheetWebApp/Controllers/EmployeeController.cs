using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Employee.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            Employee employee = _unitOfWork.Employee.GetOneById(id);
            return (employee == null) ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            return Ok(_unitOfWork.Employee.Save(employee));
        }

        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            return Ok(_unitOfWork.Employee.Update(employee));
        }

        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            return Ok(_unitOfWork.Employee.Delete(employee));
        }
    }
}
