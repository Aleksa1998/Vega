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
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IProjectService _projectService;

        public ProjectController(IUnitOfWork unitOfWork, IProjectService projectService)
        {
            _unitOfWork = unitOfWork;
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {          
            return Ok(_unitOfWork.Project.GetAll());
        }

        [HttpPost("client")]
        public IActionResult GetAllForClient(ClientShowDTO client)
        {
            return Ok(_projectService.GetAllProjectsForClient(client.Id));
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            Project project = _unitOfWork.Project.GetOneById(id);
            return (project == null) ? NotFound() : Ok(project);
        }

        [HttpPost]
        public IActionResult Save(Project project)
        {
            return Ok(_unitOfWork.Project.Save(project));
        }

        [HttpPost("update")]
        public IActionResult Update(Project project)
        {
            return Ok(_unitOfWork.Project.Update(project));
        }

        [HttpPost("delete")]
        public IActionResult Delete(Project project)
        {
            return Ok(_unitOfWork.Project.Delete(project));
        }
    }
}
