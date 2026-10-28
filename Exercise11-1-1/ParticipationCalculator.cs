namespace StudentParticipationAppendix;

public class ParticipationCalculator
{
    public int Calculate(Student student, List<ParticipationRecord> records, string rule)
    {
        List<ParticipationRecord> studentRecords = new List<ParticipationRecord>();
        foreach (ParticipationRecord record in records)
        {
            if (record.Student.CanvasId == student.CanvasId)
            {
                studentRecords.Add(record);
            }
        }

        int total = 0;
        if (rule == "all")
        {
            foreach (ParticipationRecord record in studentRecords)
            {
                total = total + record.Points;
            }
        }
        else if (rule == "daily")
        {
            List<ParticipationRecord> creditedRecords = new List<ParticipationRecord>();
            foreach (ParticipationRecord record in studentRecords)
            {
                bool alreadyCredited = false;
                // Compare with previously credited events using ordinary loops.
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
        }
        else
        {
            throw new ArgumentException("Choose all or daily for the scoring rule.", nameof(rule));
        }

        return total;
    }
}
