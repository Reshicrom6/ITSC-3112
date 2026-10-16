using Assignment9_1.DataTransferObjects;
using Assignment9_1.Domain;
using Assignment9_1.Exceptions;

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
        var account = _staffRepository.FindByUsername(username);
        
        if (account == null)
            throw new InvalidCredentialException();
        
        VerifyCredentialsAndPermissions(account, password);
        
        return CreateSessionToken(account);
    }

    private static void VerifyCredentialsAndPermissions(StaffAccount account, string password)
    {
        if (account.Password != password)
            throw new InvalidCredentialException();
        
        if (!account.CanManageParticipation)
            throw new InvalidCredentialException();
    }

    private static SessionTokenDto CreateSessionToken(StaffAccount account)
    {
        
        return new SessionTokenDto(
            Guid.NewGuid().ToString(),
            account.Username,
            account.DisplayName);
    }
}
