using Moq;
using P2_ASTRO.API.Model;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Service;
using P2_ASTRO.API.Exceptions;
using P2_ASTRO.API.Util;
using P2_ASTRO.API.DTO;

namespace P2_ASTRO.TEST;

public class UnitTest1
{
    #region CreateTests
    [Fact]
    public void CreateNewUserTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        var expectedUser = new User() 
        {
            Username = "JTheyskens", 
            Password = "password3",
            UserId = 7
        };

        mockRepo.Setup(repo => repo.CreateNewUser(It.IsAny<User>())).Returns(expectedUser);

        // Act
        var newUserInDTO =  new UserInDTO(){Username = "JTheyskenqs", Password = "password3"};
        var newUser = userService.CreateNewUser(newUserInDTO);
        newUser.UserId = 7;

        // Assert
        Assert.NotNull(newUser);
        Assert.Equal(expectedUser.UserId, newUser.UserId);
        Assert.Equal(expectedUser.Username, newUser.Username);
            
    }

        [Fact]
    public void CreateNewReviewTest()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        var expectedReview = new Review() 
        {
            Comment = "First!",
            UserId = 1
        };

        mockRepo.Setup(repo => repo.CreateNewReview(It.IsAny<Review>())).Returns(expectedReview);

        // Act
        var newReviewInDTO =  new ReviewInDTO() 
        {
            Comment = "First!",
            UserId = 1
        };

        var newReview = reviewService.CreateNewReview(newReviewInDTO);

        // Assert
        Assert.NotNull(newReview);
        Assert.Equal(expectedReview.UserId, newReview.UserId);
        Assert.Equal(expectedReview.Comment, newReview.Comment);
            
    }

            [Fact]
    public void CreateNewPODTest()
    {
        // Arrange
        Mock<IPODRepository> mockRepo = new();
        API.Util.Utility util = new();
        PODService podService = new (mockRepo.Object, util);

        var expectedPOD = new POD() 
        {
            PODId = 1,
            URL = "www.test.com",
            Title = "Test",
            Explanation = "This is a test"
        };

        mockRepo.Setup(repo => repo.CreateNewPOD(It.IsAny<POD>())).Returns(expectedPOD);

        // Act
        var newPODInDTO =  new PODInDTO() 
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            URL = "www.test.com",
            Title = "Test",
            Explanation = "This is a test"
        };

        var newPOD = podService.CreateNewPOD(newPODInDTO);

        // Assert
        Assert.NotNull(newPOD);
        Assert.Equal(expectedPOD.URL, newPOD.URL);
        Assert.Equal(expectedPOD.Title, newPOD.Title);
        Assert.Equal(expectedPOD.Explanation, newPOD.Explanation);  
    }
    #endregion

    #region GetAllTests

    [Fact]
    public void GetAllUsersTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        var userList = new List<User>
        {
            new User(){UserId = 1, Username = "Test User 1", Password = "password1", Email = "testme1@hotmail.com"},
            new User(){UserId = 2, Username = "Test User 2", Password = "password2", Email = "testme2@hotmail.com"},
            new User(){UserId = 3, Username = "Test User 3", Password = "password3", Email = "testme3@hotmail.com"},
            new User(){UserId = 4, Username = "Test User 4", Password = "password4", Email = "testme4@hotmail.com"}
        };

        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(userList);

        var dtoList = new List<UserOutDTO>();
        foreach(var u in userList)
        {
            var dto = util.UserToUserOutDTO(u);
            dtoList.Add(dto);
        }
        
        //Act
        var result = userService.GetAllUsers().ToList();
        
        //Assert
        for (int i = 0; i < dtoList.Count; i++)
        {
            Assert.Equal(dtoList[i].UserId, result[i].UserId);
            Assert.Equal(dtoList[i].Username, result[i].Username);
            Assert.Equal(dtoList[i].Email, result[i].Email);
        }


    }

    [Fact]
    public void GetAllReviewsTest()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        var reviewList = new List<Review> 
        {
            new Review()
            {
                Comment = "Test 1",
                ReviewId = 1,
                UserId = 1,
                PODId = 1,
                CommentTime = DateTime.UtcNow
            },
            new Review()
            {
                Comment = "Test 2",
                ReviewId = 2,
                UserId = 2,
                PODId = 2,
                CommentTime = DateTime.UtcNow
            },
            new Review()
            {
                Comment = "Test 3",
                ReviewId = 3,
                UserId = 3,
                PODId = 3,
                CommentTime = DateTime.UtcNow
            },
        };

        mockRepo.Setup(repo => repo.GetAllReviews()).Returns(reviewList);

        var dtoList = new List<ReviewOutDTO>();
        foreach(var r in reviewList)
        {
            var dto = util.ReviewToReviewOutDTO(r);
            dtoList.Add(dto);
        }
        
        //Act
        var result = reviewService.GetAllReviews().ToList();
        
        //Assert
        for (int i = 0; i < dtoList.Count; i++)
        {
            Assert.Equal(dtoList[i].Comment, result[i].Comment);
            Assert.Equal(dtoList[i].CommentTime, result[i].CommentTime);
            Assert.Equal(dtoList[i].UserId, result[i].UserId); 
        }
    }

    [Fact]
    public void GetAllPODsTest()
    {
        // Arrage
        Mock<IPODRepository> mockRepo = new();
        API.Util.Utility util = new();
        PODService podService = new(mockRepo.Object, util);

        var podList = new List<POD>
        {
            new POD() {PODId = 1, Explanation = "test 1", Title = "Test title 1", URL = "www.test.com", Date = DateOnly.FromDateTime(DateTime.Now)},
            new POD() {PODId = 2, Explanation = "test 2", Title = "Test title 2", URL = "www.test.com", Date = DateOnly.FromDateTime(DateTime.Now)},
            new POD() {PODId = 3, Explanation = "test 3", Title = "Test title 3", URL = "www.test.com", Date = DateOnly.FromDateTime(DateTime.Now)}
        };

        mockRepo.Setup(repo => repo.GetAllPODs()).Returns(podList);

        // Act
        var result = podService.GetAllPODs().ToList();

        // Assert
        for(int i = 0; i < podList.Count; i++)
        {
            Assert.Equal(result[i].Date, podList[i].Date);
            Assert.Equal(result[i].Explanation, podList[i].Explanation);
            Assert.Equal(result[i].PODId, podList[i].PODId);
            Assert.Equal(result[i].Title, podList[i].Title);
            Assert.Equal(result[i].URL, podList[i].URL);
        }
    
    }
    #endregion

    #region GetByIdTests
    [Fact]
    public void GetUserByIdTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);
        var usersList = new List<User>
        {
            new User() {Username = "TestUser1", Password = "Password1", UserId = 1, Email = "Test1@gmail.com"},
            new User() {Username = "TestUser2", Password = "Password2", UserId = 2, Email = "Test2@gmail.com"},
            new User() {Username = "TestUser3", Password = "Password3", UserId = 3, Email = "Test3@gmail.com"},
        };

        var expectedUser = new User(){Username = "TestUser4", Password = "Password4", UserId = 4, Email = "Test4@gmail.com"};

        mockRepo.Setup(repo => repo.GetUserById(expectedUser.UserId)).Returns(expectedUser);

        // Act
        var user = userService.GetUserById(expectedUser.UserId);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(expectedUser.UserId, user.UserId);
        Assert.Equal(expectedUser.Username, user.Username);
        Assert.Equal(expectedUser.Username, user.Username);
        Assert.Equal(expectedUser.Email, user.Email);
    }

    [Fact]
    public void GetReviewById()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        var expectedReview = new Review() 
        {
            Comment = "This is a test comment!", 
            ReviewId = 1,
            UserId = 11,
            PODId = 111,
            CommentTime = DateTime.UtcNow,
        };

        mockRepo.Setup(repo => repo.GetReviewById(expectedReview.ReviewId)).Returns(expectedReview);

        // Act
        var review = reviewService.GetReviewById(expectedReview.ReviewId);

        Assert.NotNull(review);
        Assert.Equal(expectedReview.Comment, review.Comment);
        Assert.Equal(expectedReview.CommentTime, review.CommentTime);
        Assert.Equal(expectedReview.UserId, review.UserId);
        Assert.Equal(expectedReview.ReviewId, review.ReviewId);

    }

    [Fact]
    public void GetPODbyIdTest()
    {
        // Arrange
        Mock<IPODRepository> mockRepo = new();
        API.Util.Utility util = new();
        PODService podService = new (mockRepo.Object, util);

        var expectedPOD = new POD() {PODId = 123, Title = "Title", URL = "www.test.com", Explanation = "test", Date = DateOnly.FromDateTime(DateTime.UtcNow)};

        mockRepo.Setup(repo => repo.GetPODbyId(expectedPOD.PODId)).Returns(expectedPOD);
   
        // Act
        var pod = podService.GetPODbyId(expectedPOD.PODId);

        // Assert
        Assert.Equal(expectedPOD.PODId, pod?.PODId);
        Assert.Equal(expectedPOD.Date, pod?.Date);
        Assert.Equal(expectedPOD.Title, pod?.Title);
        Assert.Equal(expectedPOD.URL, pod?.URL);
        Assert.Equal(expectedPOD.Explanation, pod?.Explanation);

    }
    #endregion

    #region DeleteTests

    [Fact]
    public void DeleteUserByIdTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        var expectedUser = new User() {Username = "DeleteMe", Password = "P@ssw0rd", UserId = 3, Email = "deleteMe@hotmail.com" };

        mockRepo.Setup(repo => repo.GetUserById(expectedUser.UserId)).Returns(expectedUser);

        // Act
        var toDelete = userService.DeleteUserById(expectedUser.UserId);

        //Assert
        Assert.Equal(expectedUser.UserId, toDelete?.UserId);
        Assert.Equal(expectedUser.Username, toDelete?.Username);
        Assert.Equal(expectedUser.Email, toDelete?.Email);

    }

    [Fact]
    public void DeleteReviewByIdTest()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        var expectedReview  = new Review() { Comment = "delete this", CommentTime = DateTime.UtcNow, UserId = 4 };
        mockRepo.Setup(repo => repo.GetReviewById(expectedReview.UserId)).Returns(expectedReview);

        // Act
        var toDelete = reviewService.DeleteReviewById(expectedReview.UserId);

        // Assert
        Assert.Equal(expectedReview.UserId, toDelete?.UserId);
        Assert.Equal(expectedReview.Comment, toDelete?.Comment);
        Assert.Equal(expectedReview.CommentTime, toDelete?.CommentTime);
    }
    #endregion

    #region ExceptionTests
    [Fact]
    public void UserNotFoundExceptionTest_OnGet()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);

        // Act
        var newUser =  new User(){Username = "NotFoundUser", Password = "exception"};
        var id = newUser.UserId;
        var action = () => userService.GetUserById(id); 

        // Assert
        Assert.Throws<UserNotFoundException>(action);
    }

    [Fact]
    public void UserNotFoundExceptionTest_OnDelete()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);

        // Act
        var newUser =  new User(){Username = "NotFoundUser", Password = "exception"};
        var id = newUser.UserId;
        var action = () => userService.DeleteUserById(id+1); 

        // Assert
        Assert.Throws<UserNotFoundException>(action);
    }


        [Fact]
    public void ReviewNotFoundExceptionTest_OnGet()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetReviewById(It.IsAny<int>())).Returns((Review)null!);

        // Act
        var newUser =  new Review()
        {
            Comment = "NotFoundReview", 
            UserId = 1,
            PODId = 1
        };

        var id = newUser.UserId;
        var action = () => reviewService.GetReviewById(id); 

        // Assert
        Assert.Throws<ReviewNotFoundException>(action);
    }

        [Fact]
    public void ReviewNotFoundExceptionTest_OnDelete()
    {
        // Arrange
        Mock<IReviewRepository> mockRepo = new();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetReviewById(It.IsAny<int>())).Returns((Review)null!);

        // Act
        var newUser =  new Review()
        {
            Comment = "NotFoundReview", 
            UserId = 1,
            PODId = 1
        };

        var id = newUser.UserId;
        var action = () => reviewService.DeleteReviewById(id); 

        // Assert
        Assert.Throws<ReviewNotFoundException>(action);
    }

        [Fact]
    public void PODNotFoundExceptionTest_OnGet()
    {
        // Arrange
        Mock<IPODRepository> mockRepo = new();
        API.Util.Utility util = new();
        PODService podService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetPODbyId(It.IsAny<int>())).Returns((POD)null!);

        // Act
        var newPOD =  new POD()
        {
            PODId = 1,
            URL = "www.test.com",
            Title = "Test",
            Explanation = "This is a test"
        };

        var id = newPOD.PODId;
        var action = () => podService.GetPODbyId(id); 

        // Assert
        Assert.Throws<PODNotFoundException>(action);
    }

    //     [Fact]
    // public void PODNotFoundExceptionTest_OnDelete()
    // {
    //     // Arrange
    //     Mock<IPODRepository> mockRepo = new();
    //     API.Util.Utility util = new();
    //     PODService podService = new (mockRepo.Object, util);

    //     mockRepo.Setup(repo => repo.GetPODbyId(It.IsAny<int>())).Returns((POD)null!);

    //     // Act
    //     var newPOD =  new POD()
    //     {
    //         PODId = 1,
    //         URL = "www.test.com",
    //         Title = "Test",
    //         Explanation = "This is a test"
    //     };

    //     var id = newPOD.PODId;
    //     var action = () => podService.DeletePODbyId(id); 

    //     // Assert
    //     Assert.Throws<PODNotFoundException>(action);
    // }
    #endregion
}