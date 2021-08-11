using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Dtos
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
        }
        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        public CategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
