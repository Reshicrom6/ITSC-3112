using Assignment9_1.DataTransferObjects;
using Assignment9_1.Exceptions;

namespace Assignment9_1.Service;

/// <summary>
/// Handles console input and output for the staff login.
/// </summary>
public class ConsoleUI
{
    private readonly AuthService _authService;

    public ConsoleUI(AuthService authService)
    {
        _authService = authService;
    }

    public void RunLogin()
    {
        // TODO: Ask for the username and password, then call Authenticate.
        Console.Write("Username: ");
        string username = Console.ReadLine() ?? "";
        
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";

        try
        {
            SessionTokenDto sessionToken =
                _authService.Authenticate(username, password);

            DisplayLoginSuccess(sessionToken);
        }
        catch (InvalidCredentialException)
        {
            DisplayLoginFailed();
        }
    }

    private static void DisplayLoginSuccess(SessionTokenDto sessionToken)
    {
        Console.WriteLine($"Username: {sessionToken.Username}");
        Console.WriteLine($"Display Name: {sessionToken.DisplayName}");
        Console.WriteLine($"Token: {sessionToken.Token}");
    }

    private static void DisplayLoginFailed()
    {
        Console.WriteLine("Login Failed. Check the username and password.");
    }
}
