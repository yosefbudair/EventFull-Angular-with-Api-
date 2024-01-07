using LearningHub.Core.Data;
using LearningHub.Core.Services;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public List<Contactu> GetAllContact()
        {
            return _contactUsService.GetAllContact();
        }


        [HttpPost]
        public bool CreateContact(Contactu Contactu)
        {
            return _contactUsService.CreateContact(Contactu);
        }


        [HttpPut]
        [Route("Update")]
        public bool UpdateContact(Contactu Contactu)
        {
            return _contactUsService.UpdateContact(Contactu);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteContact(int id)
        {
            return _contactUsService.DeleteContact(id);
        }


        [HttpGet]
        [Route("GETBYID/{id}")]
        public Contactu GETContactBYID(int id)
        {
            return _contactUsService.GETContactBYID(id);
        }


    }
   
}
