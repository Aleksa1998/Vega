using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetWebApp.Interface.Repository
{
    public interface IRepository<T>
    {
        T Delete(T obj);
        T Save(T obj);
        T Update(T obj);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
    }
}
