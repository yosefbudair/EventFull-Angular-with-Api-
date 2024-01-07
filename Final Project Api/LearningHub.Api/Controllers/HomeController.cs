using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public Home UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Pages", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            Home item = new Home();

            item.Image = fileName;

            return item;

        }

        [HttpGet]
        public List<Home> GetAllHome()
        {
            return _homeService.GetAllHome();
        }


        [HttpPost]
        public bool CreateHome(Home home)
        {
            return _homeService.CreateHome(home);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteHome(int id)
        {
            return _homeService.DeleteHome(id);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateHome(Home home)
        {
            return _homeService.UpdateHome(home);
        }

      

        [HttpGet]
        [Route("GETBYID/{id}")]
        public Home GETHomeBYID(int id)
        {
            return _homeService.GETHomeBYID(id);
        }
    }
}
