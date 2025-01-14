using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.Repository;

public interface IUserRepository{

    User CreateNewUser(User newUser); 
    IEnumerable<User> GetAllUsers(); 
    User? GetUserById(int id); 
    
    //User? GetUserByUsername(string name);
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
}

//POD----
//GET the POD external API ----> in the frontEnd (demo 1/8/2025)
//POST the POD in our own DB
//GET POD in our own DB
//GET serch our own DB by date?
//GET all pictures (eager as default), .Include(comments) too

//User-----
//POST new user to our DB
//GET to match the username&password (basic login)
//GET userInfo by searching username 

//Reviews-----
//POST review to the picture in our own DB
//GET all reviews from the picture
//