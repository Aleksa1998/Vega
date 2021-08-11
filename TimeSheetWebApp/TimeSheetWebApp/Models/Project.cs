using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Models
{
    public class Project
    {
        public Project()
        {
        }
        public Project(int id, string name, string description, int clientId, int leadId, ProjectStatus status)
        {
            Id = id;
            Name = name;
            Description = description;
            ClientId = clientId;
            LeadId = leadId;
            Status = status;
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int? LeadId { get; set; }
        public virtual Employee Lead { get; set; }
        public virtual ProjectStatus Status { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public bool IsDeleted { get; set; }
    }
}
