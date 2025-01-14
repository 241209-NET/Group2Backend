using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Exceptions;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Util;

namespace P2_ASTRO.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly Utility _utility;
    public UserService(IUserRepository userRepository, Utility utility)
    {
        _userRepository = userRepository;
        _utility = utility;
    }

    public IEnumerable<UserOutDTO> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users.Select(_utility.UserToUserOutDTO);
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

        if (user is not null)
        {
            _userRepository.DeleteUserById(id);
            return _utility.UserToUserOutDTO(user);
        }

        throw new UserNotFoundException();
    }

    public UserOutDTO? GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);

        if (user is null) 
            throw new UserNotFoundException();

        return _utility.UserToUserOutDTO(user);
    }

    public UserOutDTO? GetUserByUsername(string username)
    {
        var user = _userRepository.GetUserByUsername(username);
        if(user is null) return null;
        return _utility.UserToUserOutDTO(user);
    }

    public UserOutDTO? LoginUser(string userName, string password)
    {
        var user = _userRepository.LoginUser(userName, password);

        if (user is null)
            throw new LoginFailedException();

        return _utility.UserToUserOutDTO(user);
    }

    public IEnumerable<UserOutDTO> GetAllUsers()
    {
        var userList = _userRepository.GetAllUsers();
        return userList.Select(_utility.UserToUserOutDTO);
    }
}