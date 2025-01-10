namespace P2_ASTRO.API.Exceptions;

public class PODNotFoundException : Exception
{
    public PODNotFoundException() 
       : this("picture not found.") {}

    public PODNotFoundException(string message) 
        : base(message) {}

    public PODNotFoundException(string message, Exception inner) 
        : base(message, inner) {}
}