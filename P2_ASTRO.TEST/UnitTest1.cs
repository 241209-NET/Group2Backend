using Moq;
using P2_ASTRO.API.Model;
using P2_ASTRO.API.Repository;
//using P2_ASTRO.API.Service;
using AutoMapper;

namespace P2_ASTRO.TEST;

public class UnitTest1
{
    [Fact]
    public void CreateNewUserTest()
    {
        Mock<IUserRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new ();
        //UserService UserService = new (mockRepo.Object, mockMapper.Object);

        List<User> userList =
        [
            new User(){Username = "JSavage", Password = "password1"},
            new User(){Username = "PPanew", Password = "P@$$w0rd1"},
            new User(){Username = "PPongpat", Password = "password2"},
           
        ];

        var newUser =  new User(){Username = "JTheyskens", Password = "password3"};

        // mockRepo.Setup(repo => repo.CreateNewUser(It.IsAny<User>()))
        //     .Callback((User u) => orderList.Add(u))
        //     .Returns(newUser);
            
    }

    [Fact]
    public void CreateReviewTest()
    {
        Mock<IUserRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new ();
        //UserService UserService = new (mockRepo.Object, mockMapper.Object);
        List<Review> reviews=
        [
            new Review(){Comment = "Test 1"},
            new Review(){Comment = "Test 2"},
            new Review(){Comment = "Test 3"},

        ];

    }
}