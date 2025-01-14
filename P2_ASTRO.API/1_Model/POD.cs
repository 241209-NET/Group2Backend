namespace P2_ASTRO.API.Model;

public class POD{
    public int PODId { get; set; }
    public int ReviewId { get; set; }
    public string? Copyright { get; set; }
    public DateOnly Date { get; set; }
    public required string Explanation { get; set; }
    public required string Title { get; set; }
    public required string URL { get; set; }

    public List<Review> Reviews { get; set; } = [];
}