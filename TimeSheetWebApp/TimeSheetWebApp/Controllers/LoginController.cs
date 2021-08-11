using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;
using TimeSheetWebApp.Repository;
using TimeSheetWebApp.Services;

namespace TimeSheetWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private LoginService loginService;
        private IConfiguration _config;

        public LoginController(IConfiguration config, AppDbContext dbContext)
        {
            _config = config;
            loginService = new LoginService(new EmployeeRepository(dbContext), _config);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = loginService.FindEmployee(login);
            if (user != null)
            {
                var tokenString = loginService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
