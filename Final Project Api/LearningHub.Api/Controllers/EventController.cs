using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;


        public EventController(IEventService eventService) 
        {
            _eventService = eventService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public Event UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Events", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            Event item = new Event();

            item.Image = fileName;

            return item;

        }

        [HttpGet]
        public List<Event> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateEvent(Event events)
        {
            return _eventService.CreateEvent(events);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateEvent(Event events)
        {
            return _eventService.UpdateEvent(events);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteEvent(int id)
        {
            return _eventService.DeleteEvent(id);
        }
        [HttpGet]
        [Route("GetEventById/{id}")]
        public Event GetEventById(int id)
        {
            return _eventService.GetEventById(id);
        }
        [HttpGet]
        [Route("SearchUserEvents")]
        public List<Event> searchUserEvent(UserSearchEvents events)
        {
            return _eventService.searchUserEvent(events);
        }



        

    }
}
