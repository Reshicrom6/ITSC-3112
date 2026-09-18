namespace Assignment5_2_1.Domain;

/// <summary>
/// Identifies the supported ways a student may participate.
/// </summary>
public enum ParticipationType
{
    /// <summary>
    /// The student asks a relevant course question.
    /// </summary>
    AskQuestion,

    /// <summary>
    /// The student answers a course question.
    /// </summary>
    AnswerQuestion,

    /// <summary>
    /// The student constructively helps another student.
    /// </summary>
    HelpOthers,

    /// <summary>
    /// The student attends an instructor or assistant office-hour session.
    /// </summary>
    AttendOfficeHours
}

/// <summary>
/// Defines how many points a participation category awards and why.
/// </summary>
/// <remarks>
/// Class invariants: points are between 1 and 20, and the rationale is not blank.
/// </remarks>
public class PointPolicy
{
    /// <summary>
    /// Initializes a point policy that awards a reasonable positive value.
    /// </summary>
    /// <param name="points">The points awarded for the category.</param>
    /// <param name="rationale">The explanation for the point value.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when points are outside the inclusive range 1 through 20.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the rationale is blank.
    /// </exception>
    public PointPolicy(int points, string rationale)
    {
        if (points < 1 || points > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points must be between 1 and 20.");
        }

        if (string.IsNullOrWhiteSpace(rationale))
        {
            throw new ArgumentException("A point-policy rationale is required.", nameof(rationale));
        }

        Points = points;
        Rationale = rationale;
    }

    /// <summary>
    /// Gets or sets the number of points awarded by the policy.
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Gets or sets the explanation for the policy.
    /// </summary>
    public string Rationale { get; set; }
}

/// <summary>
/// Describes one recognized participation category and its composed point policy.
/// </summary>
/// <remarks>
/// Class invariants: the identifier is not empty, the name and description are not
/// blank, and a point policy is always present.
/// </remarks>
public class ParticipationCategory
{
    /// <summary>
    /// Initializes a participation category in a valid state.
    /// </summary>
    /// <param name="id">The category's stable identifier.</param>
    /// <param name="name">The short category name.</param>
    /// <param name="description">The behavior that qualifies for this category.</param>
    /// <param name="type">The category's predefined participation type.</param>
    /// <param name="pointPolicy">The policy composed by the category.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the identifier is empty or a text value is blank.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the point policy is null.
    /// </exception>
    public ParticipationCategory(
        Guid id,
        string name,
        string description,
        ParticipationType type,
        PointPolicy pointPolicy)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("A category identifier is required.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A category name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("A category description is required.", nameof(description));
        }

        ArgumentNullException.ThrowIfNull(pointPolicy);

        Id = id;
        Name = name;
        Description = description;
        Type = type;
        PointPolicy = pointPolicy;
    }

    /// <summary>
    /// Gets the stable identifier used by repositories.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the category's short display name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the behavior that qualifies for the category.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets the predefined participation type represented by the category.
    /// </summary>
    public ParticipationType Type { get; }

    /// <summary>
    /// Gets the point policy used by the category.
    /// </summary>
    public PointPolicy PointPolicy { get; }

    /// <summary>
    /// Gets the examples instructors have associated with this category.
    /// </summary>
    public List<string> Examples { get; } = new();

    /// <summary>
    /// Changes the category name while preserving the nonblank-name invariant.
    /// </summary>
    /// <param name="newName">The replacement category name.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the replacement name is blank.
    /// </exception>
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("A category name is required.", nameof(newName));
        }

        Name = newName;
    }

    /// <summary>
    /// Returns a concise category description for console output.
    /// </summary>
    /// <returns>The category name, type, and current point value.</returns>
    public override string ToString()
    {
        return $"{Name} - {PointPolicy.Points} points";
    }
}
