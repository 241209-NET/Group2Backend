using P2_ASTRO.API.Model;
using P2_ASTRO.API.Data;

namespace P2_ASTRO.API.Repository;

public class UserRepository : IUserRepository 
{

    private readonly AstroContext _astroContext;

    public UserRepository(AstroContext astroContext) => _astroContext = astroContext;

    public User CreateNewUser(User newUser)
    {
        throw new NotImplementedException();
    }

    public User? DeleteUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User? GetUserById(int id)
    {
        throw new NotImplementedException();
    }
}