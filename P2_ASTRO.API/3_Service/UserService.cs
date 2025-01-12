using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Util;

namespace P2_ASTRO.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly Utility _utility;
    public UserService(IUserRepository userRepository, Utility utility){
        _userRepository = userRepository;
        _utility = utility;
    }

    public UserOutDTO CreateNewUser(UserInDTO newUserInDTO)
    {
        var user = _utility.UserInDTOToUser(newUserInDTO);
        var newUser = _userRepository.CreateNewUser(user);
        return _utility.UserToUserOutDTO(newUser);
    }

    public UserOutDTO? DeleteUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if(user is null) return null;
        var deletedUser = _userRepository.DeleteUserById(id);
        if(deletedUser is null) return null;
        return _utility.UserToUserOutDTO(deletedUser);
    }

    public UserOutDTO? GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if(user is null) return null;
        return _utility.UserToUserOutDTO(user);
    }

    public UserOutDTO? GetUserByUsername(string username)
    {
        var user = _userRepository.GetUserByUsername(username);
        if(user is null) return null;
        return _utility.UserToUserOutDTO(user);
    }

    public UserOutDTO? LoginUserByUsernameAndPassword(string userName, string password)
    {
        var user = _userRepository.LoginUserByUsernameAndPassword(userName, password);
        if(user is null) return null;
        return _utility.UserToUserOutDTO(user);
    }
}