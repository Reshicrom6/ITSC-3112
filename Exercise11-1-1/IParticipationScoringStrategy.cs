namespace StudentParticipationAppendix;

/// <summary>
/// Defines an interchangeable algorithm for calculating credited points.
/// </summary>
public interface IParticipationScoringStrategy
{
    int Calculate(List<ParticipationRecord> records);
}
