using System.Collections.Generic;
using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class UserInDTO
{
    public required string Name {get; set;}
    public required string Password {get; set;}
    public User UserToDTO()
    {
        var newUser = new User()
        {
            Username = Name,
            Password = this.Password
        };
        return newUser;
    }
}

public class UserOutDTO
{
    public required string Name { get; set; }

    public List<Review> Reviews = [];
}