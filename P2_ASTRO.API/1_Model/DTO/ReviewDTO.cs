using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class ReviewInDTO
{
    public required string Comment { get; set; }
    public int UserId { get; set; } = 0;    //set defualt userId to 0, if no input for Anonymous user case
}

public class ReviewOutDTO
{
    public required string Comment { get; set; }
    public  int UserId { get; set; }
    public DateTime CommentTime { get; set; }
}