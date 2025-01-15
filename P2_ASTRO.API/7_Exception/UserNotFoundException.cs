namespace P2_ASTRO.API.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() 
       : this("User not found.") {}

    public UserNotFoundException(string message) 
        : base(message) {}

    public UserNotFoundException(string message, Exception inner) 
        : base(message, inner) {}
}