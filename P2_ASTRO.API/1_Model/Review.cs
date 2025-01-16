namespace P2_ASTRO.API.Model;

public class Review
{
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int PODId { get; set; }
    public required string Comment { get; set; }
    public DateTime CommentTime { get; set; }
    public User? User { get; set; }
}