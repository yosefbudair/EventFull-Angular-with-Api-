using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {

        private readonly IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService ;
        }

        [Route("uploadImage")]
        [HttpPost]
        public Aboutu UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Pages", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            Aboutu item = new Aboutu();

            item.Image = fileName;

            return item;

        }

        [HttpGet]
        public List<Aboutu> GetAllAboutUs()
        {
            return _aboutUsService.GetAllAboutUs();
        }


        [HttpPost]
        public bool CreateAboutUs(Aboutu aboutu)
        {
            return _aboutUsService.CreateAboutUs(aboutu);
        }


        [HttpPut]
        [Route("Update")]
        public bool UpdateAboutUs(Aboutu aboutu)
        {
            return _aboutUsService.UpdateAboutUs(aboutu);
        }




        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAboutUs(int id)
        {
            return _aboutUsService.DeleteAboutUs(id);
        }

        [HttpGet]
        [Route("GETBYID/{id}")]
        public Aboutu GETAboutUsBYID(int id)
        {
            return _aboutUsService.GETAboutUsBYID(id);
        }
    }
}
