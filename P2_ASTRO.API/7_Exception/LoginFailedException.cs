namespace P2_ASTRO.API.Exceptions;

public class LoginFailedException : Exception
{
    public LoginFailedException() 
       : this("Login failed. Check your login credentials and try again.") {}

    public LoginFailedException(string message) 
        : base(message) {}

    public LoginFailedException(string message, Exception inner) 
        : base(message, inner) {}
}