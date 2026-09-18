namespace Exercise5_2_1.Domain;

public interface IParticipationAdministrator
{
    ParticipationRecord RecordParticipation(
        Guid id,
        Student student,
        ParticipationCategory category,
        DateTime occurredAt,
        string? notes = null);

    void UpdateParticipationNotes(
        ParticipationRecord record,
        string? notes);
}