using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Interface.Service
{
    public interface ICategoryService : IService<Category>
    {
        List<CategoryDTO> GetAllCategories();
    }
}
