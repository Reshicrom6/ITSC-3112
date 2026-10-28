namespace StudentParticipationAppendix;

public class ParticipationCalculator
{
    private readonly IParticipationScoringStrategy _strategy;

    public ParticipationCalculator(IParticipationScoringStrategy strategy)
    {
        ArgumentNullException.ThrowIfNull(strategy);
        _strategy = strategy;
    }

    public int Calculate(Student student, List<ParticipationRecord> records)
    {
        List<ParticipationRecord> studentRecords = new List<ParticipationRecord>();
        foreach (ParticipationRecord record in records)
        {
            if (record.Student.CanvasId == student.CanvasId)
            {
                studentRecords.Add(record);
            }
        }

        return _strategy.Calculate(studentRecords);
    }
}
