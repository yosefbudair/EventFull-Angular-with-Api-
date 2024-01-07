using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public Service UploadImage()
        {

            var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Icons", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            Service item = new Service();

            item.Image = fileName;

            return item;

        }


        [HttpPost]
        public bool CreateServices(Service service)
        {
            return _servicesService.CreateServices(service);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteServices(int id)
        {
            return _servicesService.DeleteServices(id);
        }


        [HttpGet]
        public List<Service> GetAllServices()
        {
            return _servicesService.GetAllServices();
        }

        [HttpGet]
        [Route("GETBYID/{id}")]
        public Service GETServicesBYID(int id)
        {
            return _servicesService.GETServicesBYID(id);
        }
        [HttpPut]
        [Route("Update")]
        public bool UpdateServices(Service service)
        {
            return _servicesService.UpdateServices(service);
        }
    }
}
