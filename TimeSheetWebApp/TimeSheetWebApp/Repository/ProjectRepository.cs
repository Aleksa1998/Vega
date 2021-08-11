using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Models;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
