namespace Assignment5_2_1.Domain;

/// <summary>
/// Records one student's participation in one category at a particular time.
/// </summary>
/// <remarks>
/// Class invariants: the identifier is not empty, the student and category are present,
/// the participation time is not in the future, and notes contain at most 250 characters.
/// </remarks>
public class ParticipationRecord
{
    /// <summary>
    /// Initializes a participation record in a valid state.
    /// </summary>
    /// <param name="id">The record's stable identifier.</param>
    /// <param name="student">The student who participated.</param>
    /// <param name="category">The category describing the participation.</param>
    /// <param name="occurredAt">The date and time at which participation occurred.</param>
    /// <param name="notes">Optional instructor notes of at most 250 characters.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the identifier is empty.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the student or category is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the participation time is in the future.
    /// </exception>
    public ParticipationRecord(
        Guid id,
        Student student,
        ParticipationCategory category,
        DateTime occurredAt,
        string? notes = null)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("A participation-record identifier is required.", nameof(id));
        }

        ArgumentNullException.ThrowIfNull(student);
        ArgumentNullException.ThrowIfNull(category);

        if (occurredAt > DateTime.Now)
        {
            throw new ArgumentOutOfRangeException(
                nameof(occurredAt),
                "Participation cannot be recorded in the future.");
        }

        ValidateNotes(notes);

        Id = id;
        Student = student;
        Category = category;
        OccurredAt = occurredAt;
        Notes = notes;
    }

    /// <summary>
    /// Gets the stable identifier used by repositories.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the student composed into this participation record.
    /// </summary>
    public Student Student { get; }

    /// <summary>
    /// Gets the category composed into this participation record.
    /// </summary>
    public ParticipationCategory Category { get; }

    /// <summary>
    /// Gets the time at which the participation occurred.
    /// </summary>
    public DateTime OccurredAt { get; }

    /// <summary>
    /// Gets the optional instructor notes.
    /// </summary>
    public string? Notes { get; private set; }

    /// <summary>
    /// Gets the points currently supplied by the record's category.
    /// </summary>
    public int AwardedPoints => Category.PointPolicy.Points;

    /// <summary>
    /// Replaces the optional notes after enforcing the record's length rule.
    /// </summary>
    /// <param name="notes">The replacement notes, or null when no notes are needed.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the notes contain more than 250 characters.
    /// </exception>
    public void UpdateNotes(string? notes)
    {
        ValidateNotes(notes);
        Notes = notes;
    }

    /// <summary>
    /// Returns a concise record description for console output.
    /// </summary>
    /// <returns>The student, category, date, awarded points, and notes.</returns>
    public override string ToString()
    {
        string displayedNotes = string.IsNullOrWhiteSpace(Notes) ? "(none)" : Notes;
        return $"{Student.Name} | {Category.Name} | {OccurredAt:g} | " +
               $"{AwardedPoints} points | Notes: {displayedNotes}";
    }

    private static void ValidateNotes(string? notes)
    {
        if (notes is not null && notes.Length > 250)
        {
            throw new ArgumentException("Participation notes cannot exceed 250 characters.", nameof(notes));
        }
    }
}
