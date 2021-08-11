using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ICategoryService _categoryService;
        public CategoryController(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetOneById(int id)
        {
            Category category = _unitOfWork.Category.GetOneById(id);
            return (category == null) ?  NotFound() : Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Save(Category category)
        {
            return Ok(_unitOfWork.Category.Save(category));
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Category category)
        {
            return Ok(_unitOfWork.Category.Update(category));
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Category category)
        {
            return Ok(_unitOfWork.Category.Delete(category));
        }
    }
}
