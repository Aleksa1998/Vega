using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public T Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetOneById(int id)
        {
            return  context.Set<T>().Find(id);
        }

        public T Save(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
            return obj;
        }

        public T Update(T obj)
        {
            context.Set<T>().Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
