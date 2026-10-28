namespace StudentParticipationAppendix;

public class AllEventsScoringStrategy : IParticipationScoringStrategy
{
    public int Calculate(List<ParticipationRecord> records)
    {
        int total = 0;
        foreach (ParticipationRecord record in records)
        {
            total = total + record.Points;
        }

        return total;
    }
}
