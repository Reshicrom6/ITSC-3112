namespace Assignment9_1.Domain;

/// <summary>
/// Represents a staff member who may sign in to manage participation data.
/// </summary>
/// <remarks>
/// This classroom exercise stores a sample password as a string so the activity
/// can stay focused on sequence diagrams, DTOs, and records.
/// </remarks>
public class StaffAccount
{
    public StaffAccount(
        string username,
        string password,
        string displayName,
        bool canManageParticipation)
    {
        Username = username;
        Password = password;
        DisplayName = displayName;
        CanManageParticipation = canManageParticipation;
    }

    public string Username { get; }

    public string Password { get; }

    public string DisplayName { get; }

    public bool CanManageParticipation { get; }
}
