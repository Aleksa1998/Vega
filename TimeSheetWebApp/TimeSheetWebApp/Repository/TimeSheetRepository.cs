using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(AppDbContext context) : base(context)
        {        
        }
    }
}
