using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Exceptions;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Util;

namespace P2_ASTRO.API.Service;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly Utility _utility;
    public ReviewService(IReviewRepository reviewRepository,Utility utility)
    {
        _reviewRepository = reviewRepository;
        _utility = utility;
    }
    public ReviewOutDTO CreateNewReview(ReviewInDTO newReviewInDTO)
    {
        var review = _utility.ReviewInDTOToReview(newReviewInDTO);
        review.CommentTime = DateTime.UtcNow;
        var newReview = _reviewRepository.CreateNewReview(review);        
        return _utility.ReviewToReviewOutDTO(newReview);
    }

    public IEnumerable<ReviewOutDTO> GetAllReviews()
    {
        var reviews = _reviewRepository.GetAllReviews();

        return reviews.Select(_utility.ReviewToReviewOutDTO);
    }

    public ReviewOutDTO? GetReviewById(int id)
    {
        var review = _reviewRepository.GetReviewById(id);

        if(review is null)
            throw new ReviewNotFoundException();

        return _utility.ReviewToReviewOutDTO(review);
    }

    public ReviewOutDTO? DeleteReviewById(int id)
    {
        var review = _reviewRepository.GetReviewById(id);

        if (review is not null)
        {
            _reviewRepository.DeleteReviewById(id);
            return _utility.ReviewToReviewOutDTO(review);
        }

        throw new ReviewNotFoundException();
    }

    public IEnumerable<ReviewOutDTO> GetReviewsByUserId(int userId)
    {
        var reviews = _reviewRepository.GetReviewsByUserId(userId);

        return reviews.Select(_utility.ReviewToReviewOutDTO);
    }
}