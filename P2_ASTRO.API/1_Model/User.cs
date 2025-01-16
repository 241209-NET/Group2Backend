using System.ComponentModel.DataAnnotations;

namespace P2_ASTRO.API.Model;

public class User
{
    public int UserId { get; set; }
    public required string Username { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public required string Password { get; set; }
}