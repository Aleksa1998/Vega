using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public class WorkingRelationshipRepository : IWorkingRelationshipRepository
    {
        private readonly AppDbContext context;

        public WorkingRelationshipRepository(AppDbContext context)
        {
            this.context = context;
        }
        public WorkingRelationship Delete(WorkingRelationship obj)
        {
            throw new NotImplementedException();
            /* context.WorkingRelationships.Remove(obj);
             context.SaveChanges();
             return obj;*/
        }

        public IEnumerable<WorkingRelationship> GetAll()
        {
            throw new NotImplementedException();
            // return context.WorkingRelationships.ToList();
        }

        public WorkingRelationship GetOneById(int id)
        {
            throw new NotImplementedException();
            // return context.WorkingRelationships.SingleOrDefault(obj => obj.Id == id);
        }

        public WorkingRelationship Save(WorkingRelationship obj)
        {
            throw new NotImplementedException();
            /*context.WorkingRelationships.Add(obj);
            context.SaveChanges();
            return obj;*/
        }

        public WorkingRelationship Update(WorkingRelationship obj)
        {
            throw new NotImplementedException();
            /* context.WorkingRelationships.Update(obj);
             context.SaveChanges();
             return obj;*/
        }
    }
}
