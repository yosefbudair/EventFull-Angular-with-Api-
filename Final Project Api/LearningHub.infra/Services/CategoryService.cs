using LearningHub.Core.Data;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryReposirory;
        public CategoryService(ICategoryRepository categoryReposirory)
        {
            this._categoryReposirory = categoryReposirory;
        }



        public List<Category> GetAllCategory()
        {
            return _categoryReposirory.GetAllCategory();
        }

        public bool CreateCategory(Category Category)
        {
            return _categoryReposirory.CreateCategory(Category);
        }


        public bool UpdateCategory(Category Category)
        {
            return _categoryReposirory.UpdateCategory(Category);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryReposirory.DeleteCategory(id);
        }

        public Category GETBYID(int id)
        {
            return _categoryReposirory.GETBYID(id);
        }

      
    }
}
