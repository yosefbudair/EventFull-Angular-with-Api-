using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaController : ControllerBase
    {
        private readonly IVisaService visaService;
        public VisaController(IVisaService visaService)
        {
           this.visaService = visaService;
        }

        [HttpGet]
        public List<Visa> GetAllVisa()
        {

            return visaService.GetAllVisa();

        }


        [HttpGet]
        [Route("getByVisaId/{id}")]
        public Visa GetByVisaId(int id)
        {
            return visaService.GetByVisaId(id);
        }
        [HttpPut]
        [Route("Update")]
        public bool updateVisa(Visa visa)
        {
            return visaService.updateVisa(visa);
        }


    }
}
