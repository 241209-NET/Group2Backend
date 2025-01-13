using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.Service;

public interface IUserService{
    UserOutDTO CreateNewUser(UserInDTO newUserInDTO); 
    UserOutDTO? GetUserById(int id); 
    UserOutDTO? DeleteUserById(int id);
    UserOutDTO? LoginUserByUsernameAndPassword(string userName, string Password);
    UserOutDTO? GetUserByUsername(string username);
    IEnumerable<UserOutDTO> GetAllUsers(); 
}

public interface IReviewService{
    ReviewOutDTO? GetReviewById(int id);
    IEnumerable<ReviewOutDTO> GetAllReviews(); 
    IEnumerable<ReviewOutDTO> GetReviewsByUserId(int userId);
    ReviewOutDTO CreateNewReview (ReviewInDTO newReviewInDTO);
}

public interface IPODService{
    PODOutDTO? GetPODbyDate(DateOnly date);
    IEnumerable<PODOutDTO> GetAllPODs();
    PODOutDTO CreateNewPOD(PODInDTO newPODInDTO);
    PODOutDTO? GetPODbyId(int PODId);
}