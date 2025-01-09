using Microsoft.AspNetCore.Mvc;
using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Service;

namespace P2_ASTRO.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{    
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    
    //Might switch to model later?
    [HttpPost]
    public IActionResult CreateNewUser([FromBody] UserInDTO newUser)
    {

        var User = _userService.CreateNewUser(newUser);
        return Ok(newUser);
        
    }


    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}