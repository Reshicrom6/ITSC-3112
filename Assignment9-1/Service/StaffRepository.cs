using Assignment9_1.Domain;

namespace Assignment9_1.Service;

/// <summary>
/// Stores the staff accounts available to the login feature.
/// </summary>
public class StaffRepository
{
    private readonly List<StaffAccount> _accounts = new()
    {
        new StaffAccount(
            "instructor",
            "Sequence9!",
            "Course Staff",
            canManageParticipation: true)
    };

    public StaffAccount? FindByUsername(string username)
    {
        // TODO: Use Find to return the account whose Username equals username.
        return null;
    }
}
