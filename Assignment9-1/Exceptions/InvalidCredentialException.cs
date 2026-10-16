namespace Assignment9_1.Exceptions;

/// <summary>
/// Indicates that a login attempt failed.
/// </summary>
public class InvalidCredentialException : Exception
{
    public InvalidCredentialException()
        : base("Login failed. Check the username and password.")
    {
    }
}
