using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IimageEventService
    {
        public List<ImageEvent> GetAllimageEvent();
        public bool CreateimageEvent(ImageEvent imageEvent);
        public bool UpdateimageEvent(ImageEvent imageEvent);
        public bool DeleteimageEvent(int id);
        public ImageEvent GETimageEventBYID(int id);
    }
}
