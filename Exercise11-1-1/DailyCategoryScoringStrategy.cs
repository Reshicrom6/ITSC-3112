namespace StudentParticipationAppendix;

public class DailyCategoryScoringStrategy : IParticipationScoringStrategy
{
    public int Calculate(List<ParticipationRecord> records)
    {
        int total = 0;
        List<ParticipationRecord> creditedRecords = new List<ParticipationRecord>();
        foreach (ParticipationRecord record in records)
        {
            bool alreadyCredited = false;
            foreach (ParticipationRecord credited in creditedRecords)
            {
                if (record.Category == credited.Category &&
                    record.OccurredAt.Date == credited.OccurredAt.Date)
                {
                    alreadyCredited = true;
                    break;
                }
            }

            if (!alreadyCredited)
            {
                total = total + record.Points;
                creditedRecords.Add(record);
            }
        }

        return total;
    }
}
