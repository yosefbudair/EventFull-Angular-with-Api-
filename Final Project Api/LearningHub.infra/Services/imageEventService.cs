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
    public class imageEventService: IimageEventService
    {
        private readonly IimageEventRepository _imageEventReposirory;
        public imageEventService(IimageEventRepository imageEventRepository)
        {
            this._imageEventReposirory = imageEventRepository;
        }



        public List<ImageEvent> GetAllimageEvent()
        {
            return _imageEventReposirory.GetAllimageEvent();
        }

        public bool CreateimageEvent(ImageEvent imageEvent)
        {
            return _imageEventReposirory.CreateimageEvent(imageEvent);
        }


        public bool UpdateimageEvent(ImageEvent imageEvent)
        {
            return _imageEventReposirory.UpdateimageEvent(imageEvent);
        }

        public bool DeleteimageEvent(int id)
        {
            return _imageEventReposirory.DeleteimageEvent(id);
        }

        public ImageEvent GETimageEventBYID(int id)
        {
            return _imageEventReposirory.GETimageEventBYID(id);
        }

    }
}
