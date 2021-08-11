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
    public class LeadRelationshipController : Controller
    {
        private readonly ILeadRelationshipService _leadRelationshipService;
        public LeadRelationshipController(ILeadRelationshipService leadRelationshipService)
        {
            _leadRelationshipService = leadRelationshipService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_leadRelationshipService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            return Ok(_leadRelationshipService.GetOneById(id));
        }

        [HttpPost]
        public IActionResult Save(LeadRelationship leadRelationship)
        {
            return Ok(_leadRelationshipService.Save(leadRelationship));
        }

        [HttpPost("update")]
        public IActionResult Update(LeadRelationship leadRelationship)
        {
            return Ok(_leadRelationshipService.Update(leadRelationship));
        }

        [HttpPost("delete")]
        public IActionResult Delete(LeadRelationship leadRelationship)
        {
            return Ok(_leadRelationshipService.Delete(leadRelationship));
        }
    }
}
