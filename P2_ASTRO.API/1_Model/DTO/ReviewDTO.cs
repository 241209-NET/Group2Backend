using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class ReviewInDTO
{
    public required string Comment {get; set;}

    public Review ReviewToDTO()
    {
        return new Review() {Comment = this.Comment};
    }
}

public class ReviewOutDTO
{
    public required string Comment { get; set; }
    public int UserId { get; set; }

}