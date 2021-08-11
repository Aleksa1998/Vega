using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace TimeSheetWebApp.Services
{
    public class LoginService
    {
        IEmployeeRepository _employeeRepository;
        IConfiguration _config;

        public LoginService(IEmployeeRepository employeeRepository, IConfiguration config)
        {
            _employeeRepository = employeeRepository;
            _config = config;
        }

        public UserModel FindEmployee(UserModel login)
        {
            var employee = _employeeRepository.GetByLoginInfo(login);
            if (employee != null)
            {
                login.Role = (employee.Role == 0) ? "Admin" : "Worker";
                login.Id = employee.Id;
                login.Name = employee.Name;
                return login;
            }
            return null;
        }

        public string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("user_id", userInfo.Id.ToString()),
                new Claim("name", userInfo.Name),
                new Claim("role", userInfo.Role),             
                new Claim (ClaimTypes.Role, userInfo.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
