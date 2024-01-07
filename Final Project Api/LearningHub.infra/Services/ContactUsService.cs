using LearningHub.Core.Data;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using LearningHub.Infra.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class ContactUsService: IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this._contactUsRepository = contactUsRepository;
        }

        public List<Contactu> GetAllContact()
        {
            return _contactUsRepository.GetAllContact();
        }

        public bool CreateContact(Contactu Contactu)
        {
            return _contactUsRepository.CreateContact(Contactu);
        }


        public bool UpdateContact(Contactu Contactu)
        {
            return _contactUsRepository.UpdateContact(Contactu);
        }

        public bool DeleteContact(int id)
        {
            return _contactUsRepository.DeleteContact(id);
        }

        public Contactu GETContactBYID(int id)
        {
            return _contactUsRepository.GETContactBYID(id);
        }
    }
}
