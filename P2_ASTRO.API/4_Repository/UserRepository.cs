using P2_ASTRO.API.Model;
using P2_ASTRO.API.Data;
using P2_ASTRO.API.Exceptions;

namespace P2_ASTRO.API.Repository;

public class UserRepository : IUserRepository 
{

    private readonly AstroContext _astroContext;

    public UserRepository(AstroContext astroContext) => _astroContext = astroContext;

    public User CreateNewUser(User newUser)
    {
        _astroContext.Users.Add(newUser);
        _astroContext.SaveChanges();
        return newUser;
    }

    public User? DeleteUserById(int id)
    {
        User? user = GetUserById(id);

        if(user is null) 
            throw new UserNotFoundException();

        //user is not null, proceed
        _astroContext.Users.Remove(user);
        _astroContext.SaveChanges();
        return user;
    }

    /*
    public IEnumerable<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }
    */

    public User? GetUserById(int id)
    {
        return _astroContext.Users.FirstOrDefault(u => u.UserId == id);
    }

    public User? LoginUserByUsernameAndPassword(string userName, string Password)
    {
        var user = _astroContext.Users.FirstOrDefault(u => u.Username == userName && u.Password == Password);
        if(user is null) return null;
        return user;
    }
}