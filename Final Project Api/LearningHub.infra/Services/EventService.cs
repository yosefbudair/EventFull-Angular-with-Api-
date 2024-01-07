using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public List<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public bool CreateEvent(Event events) 
        { 
            return _eventRepository.CreateEvent(events); 
        }
        public bool UpdateEvent(Event events)
        {
            return _eventRepository.UpdateEvent(events);
        }
        public bool DeleteEvent(int id)
        {
            return _eventRepository.DeleteEvent(id);
        }
        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }
        public List<Event> searchUserEvent(UserSearchEvents events)
        {
            return _eventRepository.searchUserEvent(events);
        }

    }
}
