using P2_ASTRO.API.Model;
using P2_ASTRO.API.Data;
using P2_ASTRO.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace P2_ASTRO.API.Repository;

public class ReviewRepository : IReviewRepository
{

    private readonly AstroContext _astroContext;

    public ReviewRepository(AstroContext astroContext) => _astroContext = astroContext;

    public Review CreateNewReview(Review newReview)
    {
        _astroContext.Reviews.Add(newReview);
        _astroContext.SaveChanges();
        return newReview;
    }

    public IEnumerable<Review> GetAllReviews()
    {
        return _astroContext.Reviews.Include(u => u.User).ToList();
    }

    public Review? GetReviewById(int reviewId)
    {
        return _astroContext.Reviews.Include(u => u.User).FirstOrDefault(r => r.ReviewId == reviewId);
    }

    public Review? DeleteReviewById(int id)
    {
        Review? review = GetReviewById(id);
        if(review is null) 
            throw new ReviewNotFoundException();

        // review is not null, proceed
        _astroContext.Reviews.Remove(review);
        _astroContext.SaveChanges();
        return review;
    }

    public IEnumerable<Review> GetReviewsByUserId(int userId)
    {
        return _astroContext.Reviews.Where(r => r.UserId == userId).Include(u => u.User).ToList();
    }
}