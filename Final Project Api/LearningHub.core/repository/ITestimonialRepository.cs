using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface ITestimonialRepository
    {
        List<Testimonial> GetAllTestimonial();
        void CreateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);

        public void UpdateTestimonial(Testimonial testimonial);

        Testimonial GetByTestimonialId(int id);
    }
}
