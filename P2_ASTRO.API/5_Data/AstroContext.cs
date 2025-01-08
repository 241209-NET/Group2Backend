using Microsoft.EntityFrameworkCore;
using P2_ASTRO.API.Model;

namespace P2_ASTRO.API.Data;

public class AstroContext : DbContext
{
    public AstroContext(){}
    public AstroContext(DbContextOptions<AstroContext> options) : base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<Review> Contacts { get; set; }
    public DbSet<POD> PODs { get; set; }

    internal void CreateNewReview(Review newReview)
    {
        throw new NotImplementedException();
    }
}