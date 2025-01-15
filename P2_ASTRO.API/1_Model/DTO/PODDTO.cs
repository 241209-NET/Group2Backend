using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.DTO;

public class PODInDTO
{
    public string? Copyright { get; set; }
    public required DateOnly Date { get; set; }
    public required string Explanation { get; set; }
    public required string Title { get; set; }
    public required string URL { get; set; }
}

public class PODOutDTO
{
    public int PODId { get; set; }
    public string? Copyright { get; set; }
    public DateOnly Date { get; set; }
    public required string Explanation { get; set; }
    public required string Title { get; set; }
    public required string URL { get; set; }

    public List<Review> Reviews { get; set; } = []; //show relation "1" user to "N" Reviews
}