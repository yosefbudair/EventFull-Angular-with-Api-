using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewEventController : ControllerBase
    {
        private readonly IUserReviewEventService _userReviewEventService ;

        public UserReviewEventController(IUserReviewEventService userReviewEventService)
        {
            _userReviewEventService = userReviewEventService;
        }
        [HttpGet]
        [Route("geteventuser/{id}")]
        public List<Event> geteventsbyuser(int id)
        {
            return _userReviewEventService.geteventsbyuser(id);
        }

        [HttpGet]
        public List<UserREvent> GetAllUevent()
        {
            return _userReviewEventService.GetAllUevent();
        }

        [HttpPost]
        [Route("CreateUevent")]
        public bool CreateUevent(UserREvent userREvent)
        {
            return _userReviewEventService.CreateUevent(userREvent);
        }

        [HttpPut]
        [Route("updateUevent")]
        public bool updateUevent(UserREvent userREvent)
        {
            return _userReviewEventService.updateUevent(userREvent);
        }
        [HttpDelete]
        [Route("DeleteUevent/{id}")]
        public bool DeleteUevent(int id)
        {
            return _userReviewEventService.DeleteUevent(id);
        }
        [HttpGet]
        [Route("getUeventById/{id}")]
        public UserREvent getUeventById(int id)
        {
            return _userReviewEventService.getUeventById(id);
        }
    }
}
