namespace Exercise5_2_1.Domain;

public class Teacher : Person, IParticipationAdministrator
{
    public Teacher(Guid id, string name, string email, string department) : base(id, name, email)
    {
        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentException("A teacher department is required.", nameof(department));
        }
        Department = department;
    }

    public string Department { get; set; }

    public override string GetRoleDescription()
    {
        return "Teacher";
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
}