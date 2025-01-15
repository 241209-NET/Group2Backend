using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class ReviewInDTO
{
    public required string Comment { get; set; }
    public int UserId { get; set; }
    public int PODId { get; set; }
}

public class ReviewOutDTO
{
    public required string Comment { get; set; }
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int PODId { get; set; }
    public DateTime CommentTime { get; set;  }
    public UserOutDTO? User { get; set; }
}