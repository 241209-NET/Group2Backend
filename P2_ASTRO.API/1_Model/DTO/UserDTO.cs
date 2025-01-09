using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class UserInDTO
{
    public required string Username {get; set;}
    public required string Password {get; set;}
    [EmailAddress]
    public string? Email { get; set; }
    }

public class UserOutDTO
{
    public int UserId { get; set; }
    public required string Username { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}