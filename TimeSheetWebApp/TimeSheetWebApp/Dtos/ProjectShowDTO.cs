using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class ProjectShowDTO
    {
        public ProjectShowDTO()
        {
        }
        public ProjectShowDTO(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Client = new ClientDTO(project.Client);
        }
        public ProjectShowDTO(int id, string name, ClientDTO client)
        {
            Id = id;
            Name = name;
            Client = client;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientDTO Client { get; set; }
    }
}
