using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class Employee
    {
        public Employee()
        {
        }
        public Employee(int id, string name, string email, string password, string username, bool isActive, float hoursPerWeek, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Username = username;
            IsActive = isActive;
            HoursPerWeek = hoursPerWeek;
            Role = role;
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public float HoursPerWeek { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Project> LeadingProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public bool IsDeleted { get; set; }
    }
}
