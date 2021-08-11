using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Interface.Service
{
    public interface ICountryService : IService<Country>
    {
        int GetOneByName(string name);
    }
}
