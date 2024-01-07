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
    public class AboutUsService:IAboutUsService
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            this._aboutUsRepository = aboutUsRepository;
        }

        public bool CreateAboutUs(Aboutu aboutu)
        {
            return _aboutUsRepository.CreateAboutUs(aboutu);
        }

        public bool DeleteAboutUs(int id)
        {
            return _aboutUsRepository.DeleteAboutUs(id);
        }

        public Aboutu GETAboutUsBYID(int id)
        {
            return _aboutUsRepository.GETAboutUsBYID(id);
        }

        public List<Aboutu> GetAllAboutUs()
        {
            return _aboutUsRepository.GetAllAboutUs();
        }

        public bool UpdateAboutUs(Aboutu aboutu)
        {
            return _aboutUsRepository.UpdateAboutUs(aboutu);
        }
    }
}
