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
        var newUserInDTO =  new UserInDTO(){Username = "JTheyskens", Password = "password3"};
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

    [Fact]
    public void UserNotFoundExceptionTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util);

        mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null!);

        // Act
        var newUser =  new User()
        {
            Username = "NotFoundUser", 
            Password = "exception"
        };

        var id = newUser.UserId;
        var action = () => userService.GetUserById(id); 

        // Assert
        Assert.Throws<UserNotFoundException>(action);
    }

        [Fact]
    public void ReviewNotFoundExceptionTest()
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
    public void PODNotFoundExceptionTest()
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
}