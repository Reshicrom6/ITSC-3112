using Assignment9_1.DataTransferObjects;
using Assignment9_1.Domain;

namespace Assignment9_1.Service;

/// <summary>
/// Coordinates staff lookup, credential checking, and session-token creation.
/// </summary>
public class AuthService
{
    private readonly StaffRepository _staffRepository;

    public AuthService(StaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public SessionTokenDto Authenticate(string username, string password)
    {
        // TODO: Find the account, check it, and return a session-token DTO.
        throw new NotImplementedException();
    }

    private static void VerifyCredentialsAndPermissions(StaffAccount account, string password)
    {
        // TODO: Compare the password and check CanManageParticipation.
        throw new NotImplementedException();
    }

    private static SessionTokenDto CreateSessionToken(StaffAccount account)
    {
        // TODO: Return a SessionTokenDto containing a new token, username, and display name.
        throw new NotImplementedException();
    }
}
