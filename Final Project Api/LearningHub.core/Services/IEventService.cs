using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IEventService
    {
        public List<Event> GetAllEvents();

        public bool CreateEvent(Event events);
        public bool UpdateEvent(Event events);
        public bool DeleteEvent(int id);
        public Event GetEventById(int id);
        public List<Event> searchUserEvent(UserSearchEvents events);
    }
}
