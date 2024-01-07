using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Route("CreateReview")]
        public bool CreateReview(Review review)
        {
            return _reviewService.CreateReview(review);
        }

        [HttpPut]
        [Route("updateReview")]
        public bool updateReview(Review review)
        {
            return _reviewService.updateReview(review);
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        public bool DeleteReview(int id)
        {
            return _reviewService.DeleteReview(id);
        }

        [HttpGet]
        public List<Review> GetAllReview()
        {
            return _reviewService.GetAllReview();
        }

        [HttpGet]
        [Route("getReviewById/{id}")]
        public Review getReviewById(int id)
        {
            return _reviewService.getReviewById(id);
        }
    }
}
