using Assignment9_1.DataTransferObjects;

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
        throw new NotImplementedException();
    }

    private static void DisplayLoginSuccess(SessionTokenDto sessionToken)
    {
        // TODO: Display the username, display name, and token.
        throw new NotImplementedException();
    }

    private static void DisplayLoginFailed()
    {
        // TODO: Display the generic login-failure message.
        throw new NotImplementedException();
    }
}
