using Microsoft.AspNetCore.Mvc;
using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Exceptions;
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

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        try
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("No user found for id = " + id);
            }
            return Ok(user);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpGet("username/{username}")]
    public IActionResult GetUserByUsername(string username)
    {
        try
        {
            var user = _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound("No user found for username = " + username);
            }
            return Ok(user);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    

    [HttpPost]
    public IActionResult CreateNewUser([FromBody] UserInDTO newUserInDTO)
    {
        var user = _userService.CreateNewUser(newUserInDTO);
        if (user == null)
        {
            return BadRequest("Invalid input for creating a new user.");
        }
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        try
        {
            var user = _userService.DeleteUserById(id);
            if (user == null)
            {
                return NotFound($"No user found to delete for id = " + id);
            }
            return Ok(user);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var userList = _userService.GetAllUsers();
        if(userList is null || !userList.Any()) 
        {
            return NotFound("No users found.");
        }
        return Ok(userList);
    }

    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] UserInDTO loginDTO)
    {
        try
        {
            var user = _userService.LoginUser(loginDTO.Username, loginDTO.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(user);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
