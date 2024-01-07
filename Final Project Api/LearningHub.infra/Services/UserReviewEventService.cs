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
    public class UserReviewEventService : IUserReviewEventService
    {
        private readonly IUserReviewEventRepository _userReviewEventRepository ;
        public UserReviewEventService(IUserReviewEventRepository userReviewEventRepository)
        {
            _userReviewEventRepository = userReviewEventRepository;
        }
        public bool CreateUevent(UserREvent userREvent)
        {
            return _userReviewEventRepository.CreateUevent(userREvent);

        }
        public bool updateUevent(UserREvent userREvent)
        {
            return _userReviewEventRepository.updateUevent(userREvent);
        }

        public bool DeleteUevent(int id)
        {
            return _userReviewEventRepository.DeleteUevent(id);
        }
        public List<UserREvent> GetAllUevent()
        {
            return _userReviewEventRepository.GetAllUevent();

        }
        public UserREvent getUeventById(int id)
        {
            return _userReviewEventRepository.getUeventById(id);
        }

        public List<Event> geteventsbyuser(int id)
        {
            return _userReviewEventRepository.geteventsbyuser(id);
        }

    }
}
