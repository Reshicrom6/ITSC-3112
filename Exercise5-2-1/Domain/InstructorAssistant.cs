namespace Exercise5_2_1.Domain;

public class InstructorAssistant : Person, IParticipationAdministrator
{
    public InstructorAssistant(
        Guid id,
        string name,
        string email,
        string assignedCourse) : base(id, name, email)
    {
        if (string.IsNullOrWhiteSpace(assignedCourse))
            throw new ArgumentException("An assigned course must be provided", nameof(assignedCourse));
        AssignedCourse = assignedCourse;
    }
    
    public string AssignedCourse { get; set; }
    
    public override string GetRoleDescription()
    {
        return "Instructor Assistant";
    }
    
    public ParticipationRecord RecordParticipation(
        Guid id,
        Student student,
        ParticipationCategory category,
        DateTime occurredAt,
        string? notes = null)
    {
        return new ParticipationRecord(id, student, category, occurredAt, notes);
    }

    public void UpdateParticipationNotes(ParticipationRecord record, string? notes)
    {
        ArgumentNullException.ThrowIfNull(record);
        record.UpdateNotes(notes);
    }

    public override string ToString()
    {
        return $"{Name}: {GetRoleDescription()} for {AssignedCourse}";
    }
}