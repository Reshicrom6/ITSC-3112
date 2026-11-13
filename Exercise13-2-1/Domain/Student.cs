namespace Exercise13_2_1.Domain;

public class Student
{
    public Guid Id { get; }
    public string Name { get; }
    public string? InstitutionalId { get; }
    public string? CanvasUserId { get; }
    public string? CanvasLoginId { get; }
    public string? Pronouns { get; }
    public string? ClassStanding { get; }
    public string? RegistrationStatus { get; }
    public string? Email { get; }
    public bool IsActive { get; }

    public Student(
        Guid id,
        string name,
        string? institutionalId,
        string? canvasUserId = null,
        string? canvasLoginId = null,
        string? pronouns = null,
        string? classStanding = null,
        string? registrationStatus = null,
        string? email = null,
        bool isActive = true)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("A student identifier is required.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (string.IsNullOrWhiteSpace(institutionalId) &&
            string.IsNullOrWhiteSpace(canvasUserId))
        {
            throw new ArgumentException("An institutional ID or Canvas user ID is required.");
        }

        Id = id;
        Name = name.Trim();
        InstitutionalId = OptionalText(institutionalId);
        CanvasUserId = OptionalText(canvasUserId);
        CanvasLoginId = OptionalText(canvasLoginId);
        Pronouns = OptionalText(pronouns);
        ClassStanding = OptionalText(classStanding);
        RegistrationStatus = OptionalText(registrationStatus);
        Email = OptionalText(email);
        IsActive = isActive;
    }

    public override string ToString() =>
        $"{Id} | {Name} | Institutional ID: {InstitutionalId ?? "(none)"} | " +
        $"Email: {Email ?? "(none)"} | Active: {IsActive}";

    private static string? OptionalText(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
