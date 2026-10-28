namespace StudentParticipationAppendix;

public class ParticipationRecord
{
    public Student Student { get; }
    public string Category { get; }
    public int Points { get; }
    public DateTime OccurredAt { get; }

    public ParticipationRecord(Student student, string category, int points, DateTime occurredAt)
    {
        ArgumentNullException.ThrowIfNull(student);
        ArgumentException.ThrowIfNullOrWhiteSpace(category);
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative.");
        }

        // This small example accepts UTC directly; it does not convert legacy timestamps.
        if (occurredAt.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("Participation timestamps must be UTC.", nameof(occurredAt));
        }

        Student = student;
        Category = category;
        Points = points;
        OccurredAt = occurredAt;
    }
}
