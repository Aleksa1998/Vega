using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(int id, string username, string password, string role, string name)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
            Name = name;
        }

        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public String Name { get; set; }
    }
}
