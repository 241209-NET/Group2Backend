using Moq;
using P2_ASTRO.API.Model;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Service;
using P2_ASTRO.API.Exceptions;
using P2_ASTRO.API.Util;

namespace P2_ASTRO.TEST;

public class UnitTest1
{
    [Fact]
    public void CreateNewUserTest()
    {
        // Arrange
        Mock<IUserRepository> mockRepo = new();
        API.Util.Utility util = new();
        UserService userService = new (mockRepo.Object, util); //, mockMapper.Object);

        List<User> userList =
        [
            new User(){Username = "JSavage", Password = "password1"},
            new User(){Username = "PPanew", Password = "P@$$w0rd1"},
            new User(){Username = "PPongpat", Password = "password2"},
           
        ];

        // Act
        var newUser =  new User(){Username = "JTheyskens", Password = "password3"};

         mockRepo.Setup(repo => repo.CreateNewUser(It.IsAny<User>()))
             .Callback((User u) => userList.Add(u))
             .Returns(newUser);

        // Assert
        Assert.Contains(newUser, userList);
        mockRepo.Verify(x => x.CreateNewUser(It.IsAny<User>()), Times.Once());
            
    }

    [Fact]
    public void UserNotFoundExceptionTest()
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
    public void CreateReviewTest()
    {
        Mock<IReviewRepository> mockRepo = new();
        //Mock<IMapper> mockMapper = new ();
        API.Util.Utility util = new();
        ReviewService reviewService = new (mockRepo.Object, util); //mockMapper.Object);
        List<Review> reviewList =
        [
            new Review(){Comment = "Test 1"},
            new Review(){Comment = "Test 2"},
            new Review(){Comment = "Test 3"},

        ];

        // Act
        var newRev = new Review(){Comment = "this is my comment!"};

        mockRepo.Setup(repo => repo.CreateNewReview(It.IsAny<Review>()))
            .Callback((Review r) => reviewList.Add(r))
            .Returns(newRev);

        // Assert
        Assert.Contains(newRev, reviewList);
        mockRepo.Verify(x => x.CreateNewReview(It.IsAny<Review>()), Times.Once());

    }
}