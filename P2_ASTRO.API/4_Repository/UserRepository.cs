namespace P2_ASTRO.API.Repository;

public class UserRepository : IUserRepository {

    private readonly AstroContext _astroContext;

    public UserRepository(UserRepository userRepository) => _astroContext = userRepository;

    
    
}