using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class ProjectDTO
    {
        public ProjectDTO()
        {
        }
        public ProjectDTO(int id, string name, string description, int clientId, int leadId, ProjectStatus status)
        {
            Id = id;
            Name = name;
            Description = description;
            ClientId = clientId;
            LeadId = leadId;
            Status = status;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int ClientId { get; set; }
       // public ClientDTO Client { get; set; }
        public int? LeadId { get; set; }
        public Employee Lead { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<TimeSheet> TimeSheets { get; set; }
        public bool IsDeleted { get; set; }
    }
}
