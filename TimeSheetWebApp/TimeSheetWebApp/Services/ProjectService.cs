using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        private IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public Project Delete(Project obj)
        {
            return _projectRepository.Delete(obj);
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Project GetOneById(int id)
        {
            return _projectRepository.GetOneById(id);
        }

        public Project Save(Project obj)
        {
            return _projectRepository.Save(obj);
        }

        public Project Update(Project obj)
        {
            return _projectRepository.Update(obj);
        }

        public List<ProjectShowDTO> GetAllProjectsForClient(int clientId)
        {
            List<ProjectShowDTO> projects = new List<ProjectShowDTO>();
            foreach(Project project in _unitOfWork.Project.GetAll())
            {
                if (project.ClientId.Equals(clientId))
                {
                    projects.Add(new ProjectShowDTO(project));
                }
            }
            return projects;
        }
        
    }
}
