using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imageEventController : ControllerBase
    {
        private readonly IimageEventService _imageEventService;


        public imageEventController(IimageEventService imageEventService)
        {
            _imageEventService = imageEventService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public ImageEvent UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\TheLearningHub\\src\\assets\\Images", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            ImageEvent item = new ImageEvent();

            item.Image = fileName;

            return item;

        }

        [HttpGet]
        public List<ImageEvent> GetAllimageEvent()
        {
            return _imageEventService.GetAllimageEvent();
        }

        [HttpPost]
        public bool CreateimageEvent(ImageEvent imageEvent)
        {
            return _imageEventService.CreateimageEvent(imageEvent);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateimageEvent(ImageEvent imageEvent)
        {
            return _imageEventService.UpdateimageEvent(imageEvent);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteimageEvent(int id)
        {
            return _imageEventService.DeleteimageEvent(id);
        }

        [HttpGet]
        [Route("GETimageEventBYID/{id}")]
        public ImageEvent GETimageEventBYID(int id)
        {
            return _imageEventService.GETimageEventBYID(id);
        }
    }
}
