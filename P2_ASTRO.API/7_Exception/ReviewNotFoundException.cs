
namespace P2_ASTRO.API.Exceptions;

public class ReviewNotFoundException : Exception
{
    public ReviewNotFoundException() {}

    public ReviewNotFoundException(string message) 
        : base(message) {}

    public ReviewNotFoundException(string message, Exception inner) 
        : base(message, inner) {}
}