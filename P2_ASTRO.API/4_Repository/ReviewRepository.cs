using P2_ASTRO.API.Model;
using P2_ASTRO.API.Data;

namespace P2_ASTRO.API.Repository;

public class ReviewRepository : IReviewRepository
{

    private readonly AstroContext _astroContext;

    public ReviewRepository(AstroContext astroContext) => _astroContext = astroContext;

    public Review CreateNewReview(Review newReview)
    {
        throw new NotImplementedException();
        // _astroContext.CreateNewReview(newReview);
    }

    public IEnumerable<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }

    public Review GetReviewById(int reviewId)
    {
        throw new NotImplementedException();
        //  _astroContext.GetReviewById(reviewId);
    }

    public IEnumerable<Review> GetReviewsByUserId(int userId)
    {
        throw new NotImplementedException();
        // _astroContext.GetReviewsByUserId(userId);
    }
}