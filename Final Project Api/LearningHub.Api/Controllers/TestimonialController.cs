using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpGet]
        public List<Testimonial> GetAllTestimonial()
        {

            return testimonialService.GetAllTestimonial();

        }


        [HttpPost]
        public void CreateTestimonial(Testimonial testimonial)
        {

            testimonialService.CreateTestimonial(testimonial);
        }

        [HttpPut]
        public void UpdateTestimonial(Testimonial testimonial)
        {
            testimonialService.UpdateTestimonial(testimonial);

        }


        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteTestimonial(int id)
        {
            testimonialService.DeleteTestimonial(id);

        }

        [HttpGet]
        [Route("gettestimonialId/{id}")]
        public Testimonial GetByTestimonialId(int id)
        {
            return testimonialService.GetByTestimonialId(id);


        }
       
    }
}
