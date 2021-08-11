using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class LeadRelationshipService : ILeadRelationshipService
    {
        private readonly ILeadRelationshipRepository _leadRelationshipRepository;

        public LeadRelationshipService(ILeadRelationshipRepository leadRelationshipRepository)
        {
            _leadRelationshipRepository = leadRelationshipRepository;
        }

        public LeadRelationship Delete(LeadRelationship obj)
        {
            return _leadRelationshipRepository.Delete(obj);
        }

        public IEnumerable<LeadRelationship> GetAll()
        {
            return _leadRelationshipRepository.GetAll();
        }

        public LeadRelationship GetOneById(int id)
        {
            return _leadRelationshipRepository.GetOneById(id);
        }

        public LeadRelationship Save(LeadRelationship obj)
        {
            return _leadRelationshipRepository.Save(obj);
        }

        public LeadRelationship Update(LeadRelationship obj)
        {
            return _leadRelationshipRepository.Update(obj);
        }
    }
}
