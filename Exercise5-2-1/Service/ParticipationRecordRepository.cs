using Assignment5_2_1.Contracts;
using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Service;

/// <summary>
/// Stores participation records in memory and calculates totals from managed records.
/// </summary>
public class ParticipationRecordRepository : IParticipationRecordRepository
{
    private readonly List<ParticipationRecord> _records = new();

    /// <inheritdoc />
    public void Add(ParticipationRecord record)
    {
        ArgumentNullException.ThrowIfNull(record);

        if (_records.Any(existing => existing.Id == record.Id))
        {
            throw new InvalidOperationException($"Participation record {record.Id} is already managed.");
        }

        _records.Add(record);
    }

    /// <inheritdoc />
    public ParticipationRecord GetById(Guid id)
    {
        return _records.Find(record => record.Id == id)
            ?? throw new KeyNotFoundException($"Participation record {id} was not found.");
    }

    /// <inheritdoc />
    public List<ParticipationRecord> GetAll()
    {
        return new List<ParticipationRecord>(_records);
    }

    /// <inheritdoc />
    public int GetTotalPointsForStudent(Guid studentId)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("A student identifier is required.", nameof(studentId));
        }

        int total = 0;

        foreach (ParticipationRecord record in _records)
        {
            if (record.Student.Id == studentId)
            {
                total += record.AwardedPoints;
            }
        }

        return total;
    }

    /// <inheritdoc />
    public void UpdateNotes(Guid id, string? notes)
    {
        ParticipationRecord record = GetById(id);
        record.UpdateNotes(notes);
    }

    /// <inheritdoc />
    public void Delete(Guid id)
    {
        ParticipationRecord record = GetById(id);
        _records.Remove(record);
    }
}
