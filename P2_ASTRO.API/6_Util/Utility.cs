using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Model;
using P2_ASTRO.API.Service;

namespace P2_ASTRO.API.Util;

public class Utility{
    //Users' DTO Conversion
    public UserOutDTO UserToUserOutDTO(User user){
        return new UserOutDTO{
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email
        };
    }

    public User UserInDTOToUser(UserInDTO userInDTO){
        return new User{
            Username = userInDTO.Username,
            Password = userInDTO.Password,
            Email = userInDTO.Email
        };
    }

    //Reviews' DTO Converion
    public ReviewOutDTO ReviewToReviewOutDTO(Review review){
        return new ReviewOutDTO{
            Comment = review.Comment,
            UserId = review.UserId,
            CommentTime = review.CommentTime,
            ReviewId = review.ReviewId,
            PODId = review.PODId,
            User = (review.User is not null) ?
                new UserOutDTO
                {
                    UserId = review.User.UserId,
                    Username = review.User.Username,
                    Email = review.User.Email
                } : null
        };
    }

    public Review ReviewInDTOToReview(ReviewInDTO reviewInDTO){
        return new Review{
            Comment = reviewInDTO.Comment,
            UserId = reviewInDTO.UserId,
            PODId = reviewInDTO.PODId
        };
    }

    //PODs' DTO Conversion
    public PODOutDTO PODToPODOutDTO(POD pod)
    {
        // add review service
        // var 
        // var reviewService = new ReviewService()
        return new PODOutDTO{
            PODId = pod.PODId,
            Copyright = pod.Copyright,
            Date = pod.Date,
            Explanation = pod.Explanation,
            Title = pod.Title,
            URL = pod.URL,
            Reviews = pod.Reviews
        };
    }

    public POD PODInDTOToPOD(PODInDTO podInDTO)
    {
        return new POD{
            Copyright = podInDTO.Copyright,
            Date = podInDTO.Date,
            Explanation = podInDTO.Explanation,
            Title = podInDTO.Title,
            URL = podInDTO.URL
        };
    }
}