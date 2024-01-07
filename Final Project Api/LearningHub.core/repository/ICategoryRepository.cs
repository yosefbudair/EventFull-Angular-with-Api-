using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface ICategoryRepository
    {

        public List<Category> GetAllCategory();
        public bool CreateCategory(Category Category);
        public bool UpdateCategory(Category Category);
        public bool DeleteCategory(int id);
        public Category GETBYID(int id);
      
    }
}
