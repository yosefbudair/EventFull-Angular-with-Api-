using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        [Route("uploadImage")]
        [HttpPost]
        public Category UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Category", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            Category item = new Category();

            item.Image = fileName;

            return item;

        }
        public CategoryController(ICategoryService categoryService)
        {   
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }

        [HttpPost]
        public bool CreateCategory(Category Category)
        {
            return _categoryService.CreateCategory(Category);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateCategory(Category Category)
        {
            return _categoryService.UpdateCategory(Category);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }

        [HttpGet]
        [Route("GETBYID/{id}")]
        public Category GETBYID(int id)
        {
            return _categoryService.GETBYID(id);
        }

    }
}
