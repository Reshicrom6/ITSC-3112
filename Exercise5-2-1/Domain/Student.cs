namespace Exercise5_2_1.Domain;

/// <summary>
/// Represents a student who may receive participation records.
/// </summary>
/// <remarks>
/// Class invariants: the identifier is not empty and the name and email are not blank.
/// </remarks>
public class Student : Person
{
    /// <summary>
    /// Initializes a student in a valid state.
    /// </summary>
    /// <param name="id">The student's stable identifier.</param>
    /// <param name="name">The student's display name.</param>
    /// <param name="email">The student's email address.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the identifier is empty or a text value is blank.
    /// </exception>
    public Student(Guid id, string name, string email) : base (id, name, email)
    {
        IsActive = true;
    }
    
    /// <summary>
    /// Gets or sets whether the student may receive new participation records.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Returns a concise student description for console output.
    /// </summary>
    /// <returns>The student's name, email, and active status.</returns>
    public override string ToString()
    {
        return $"{Name} ({Email}) - Active: {IsActive}";
    }

    public override string GetRoleDescription()
    {
        return "Student";
    }
}
