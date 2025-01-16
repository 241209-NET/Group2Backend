using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.Repository;

public interface IUserRepository{

    User CreateNewUser(User newUser); 

    IEnumerable<User> GetAllUsers(); 

    User? GetUserById(int id); 
    
    User? DeleteUserById(int id);

    User? LoginUser(string userName, string Password);

    User? GetUserByUsername(string username);
}

public interface IReviewRepository{

    Review? GetReviewById(int id);

    IEnumerable<Review> GetAllReviews(); 

    IEnumerable<Review> GetReviewsByUserId(int userId);

    Review? DeleteReviewById(int id);

    Review CreateNewReview (Review newReview);

}

public interface IPODRepository{

    POD? GetPODbyDate(DateOnly date);

    IEnumerable<POD> GetAllPODs();

    POD CreateNewPOD(POD newPOD);

    POD? GetPODbyId(int PODId);

    List<Review> SetPODReviews(int PODId);
}