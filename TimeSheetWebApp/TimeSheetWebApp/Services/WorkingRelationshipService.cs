using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class WorkingRelationshipService : IWorkingRelationshipService
    {
        private readonly IWorkingRelationshipRepository _workingRelationshipRepository;

        public WorkingRelationshipService(IWorkingRelationshipRepository workingRelationshipRepository)
        {
            _workingRelationshipRepository = workingRelationshipRepository;
        }

        public WorkingRelationship Delete(WorkingRelationship obj)
        {
            return _workingRelationshipRepository.Delete(obj);
        }

        public IEnumerable<WorkingRelationship> GetAll()
        {
            return _workingRelationshipRepository.GetAll();
        }

        public WorkingRelationship GetOneById(int id)
        {
            return _workingRelationshipRepository.GetOneById(id);
        }

        public WorkingRelationship Save(WorkingRelationship obj)
        {
            return _workingRelationshipRepository.Save(obj);
        }

        public WorkingRelationship Update(WorkingRelationship obj)
        {
            return _workingRelationshipRepository.Update(obj);
        }
    }
}
