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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public bool CreateReview(Review review)
        {
            return _reviewRepository.CreateReview(review);
        }
        public bool updateReview(Review review)
        {
            return _reviewRepository.updateReview(review);
        }
        public bool DeleteReview(int id)
        {
            return _reviewRepository.DeleteReview(id);
        }
        public List<Review> GetAllReview()
        {
            return _reviewRepository.GetAllReview();
        }
        public Review getReviewById(int id)
        {
            return _reviewRepository.getReviewById(id);
        }
    }
}
