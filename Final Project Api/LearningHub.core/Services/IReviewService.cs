using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IReviewService
    {
        bool CreateReview(Review review);
        bool updateReview(Review review);
        bool DeleteReview(int id);
        List<Review> GetAllReview();
        Review getReviewById(int id);
    }
}
