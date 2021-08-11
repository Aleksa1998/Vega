using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public class LeadRelationshipRepository : ILeadRelationshipRepository
    {
        private readonly AppDbContext context;

        public LeadRelationshipRepository(AppDbContext context)
        {
            this.context = context;
        }
        public LeadRelationship Delete(LeadRelationship obj)
        {
            throw new NotImplementedException();
            /*context.LeadRelationships.Remove(obj);
            context.SaveChanges();
            return obj;*/
        }

        public IEnumerable<LeadRelationship> GetAll()
        {
            throw new NotImplementedException();
            //return context.LeadRelationships.ToList();
        }

        public LeadRelationship GetOneById(int id)
        {
            throw new NotImplementedException();
            // return context.LeadRelationships.SingleOrDefault(obj => obj.Id == id);
        }

        public LeadRelationship Save(LeadRelationship obj)
        {
            throw new NotImplementedException();
            /* context.LeadRelationships.Add(obj);
             context.SaveChanges();
             return obj;*/
        }

        public LeadRelationship Update(LeadRelationship obj)
        {
            throw new NotImplementedException();
            /* context.LeadRelationships.Update(obj);
             context.SaveChanges();
             return obj;*/
        }
    }
}
