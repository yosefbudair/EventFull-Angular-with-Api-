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
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
           this.testimonialRepository = testimonialRepository;
        }


        public List<Testimonial> GetAllTestimonial()
        {
            return testimonialRepository.GetAllTestimonial();
        }

        public void CreateTestimonial(Testimonial testimonial)
        {

            testimonialRepository.CreateTestimonial(testimonial);
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            testimonialRepository.UpdateTestimonial(testimonial);

        }

        public void DeleteTestimonial(int id)
        {
            testimonialRepository.DeleteTestimonial(id);

        }
        public Testimonial GetByTestimonialId(int id)
        {
            return testimonialRepository.GetByTestimonialId(id);


        }
    }
}
