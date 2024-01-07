using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IUserReviewEventService
    {
        bool CreateUevent(UserREvent userREvent);
        bool updateUevent(UserREvent userREvent);
        bool DeleteUevent(int id);
        List<UserREvent> GetAllUevent();
        UserREvent getUeventById(int id);
        List<Event> geteventsbyuser(int id);
    }
}
