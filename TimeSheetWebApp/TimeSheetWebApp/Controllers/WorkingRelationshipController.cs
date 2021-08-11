using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkingRelationshipController : Controller
    {
        private readonly IWorkingRelationshipService _workingRelationshipService;
        public WorkingRelationshipController(IWorkingRelationshipService workingRelationshipService)
        {
            _workingRelationshipService = workingRelationshipService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_workingRelationshipService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            return Ok(_workingRelationshipService.GetOneById(id));
        }

        [HttpPost]
        public IActionResult Save(WorkingRelationship workingRelationship)
        {
            return Ok(_workingRelationshipService.Save(workingRelationship));
        }

        [HttpPost("update")]
        public IActionResult Update(WorkingRelationship workingRelationship)
        {
            return Ok(_workingRelationshipService.Update(workingRelationship));
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkingRelationship workingRelationship)
        {
            return Ok(_workingRelationshipService.Delete(workingRelationship));
        }
    }
}
