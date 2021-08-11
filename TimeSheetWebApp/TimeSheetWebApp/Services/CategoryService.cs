using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetWebApp.Dtos;
using TimeSheetWebApp.Interface.Repository;
using TimeSheetWebApp.Interface.Service;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public Category Delete(Category obj)
        {
            return _categoryRepository.Delete(obj);
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (Category category in _unitOfWork.Category.GetAll())
            {
                categories.Add(new CategoryDTO(category));
            }
            return categories;
        }

        public Category GetOneById(int id)
        {
            return _categoryRepository.GetOneById(id);
        }

        public Category Save(Category obj)
        {
            return _categoryRepository.Save(obj);
        }

        public Category Update(Category obj)
        {
            return _categoryRepository.Update(obj);
        }
    }
}
