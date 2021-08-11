using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Country.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOneById(int id)
        {
            Country country = _unitOfWork.Country.GetOneById(id);
            return (country == null) ? NotFound() : Ok(country);
        }

        [HttpPost]
        public IActionResult Save(Country country)
        {
            return Ok(_unitOfWork.Country.Save(country));
        }

        [HttpPost("update")]
        public IActionResult Update(Country country)
        {
            return Ok(_unitOfWork.Country.Update(country));
        }

        [HttpPost("delete")]
        public IActionResult Delete(Country country)
        {
            return Ok(_unitOfWork.Country.Delete(country));
        }
    }
}
