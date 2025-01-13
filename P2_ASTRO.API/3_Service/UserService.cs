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

    /*
        public Order DeleteOrderById(int id)
    {
        var order = GetOrderById(id);

        if(order is not null) 
            _OrderRepository.DeleteOrderById(id);

        return order!;
    }
    */

    public UserOutDTO? GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);

        if (user is null) 
            throw new UserNotFoundException();

        return _utility.UserToUserOutDTO(user);
    }

    public UserOutDTO? LoginUserByUsernameAndPassword(string userName, string password)
    {
        var user = _userRepository.LoginUserByUsernameAndPassword(userName, password);

        if (user is null)
            throw new UserNotFoundException();

        return _utility.UserToUserOutDTO(user);
    }
}