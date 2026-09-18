using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Contracts;

/// <summary>
/// Defines in-memory CRUD operations for participation records.
/// </summary>
public interface IParticipationRecordRepository
{
    /// <summary>
    /// Adds one participation record while preserving identifier uniqueness.
    /// </summary>
    /// <param name="record">The valid record to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the record is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the identifier is already managed.
    /// </exception>
    void Add(ParticipationRecord record);

    /// <summary>
    /// Retrieves one record by identifier.
    /// </summary>
    /// <param name="id">The identifier to locate.</param>
    /// <returns>The matching participation record.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    ParticipationRecord GetById(Guid id);

    /// <summary>
    /// Gets a copy of all managed participation records.
    /// </summary>
    /// <returns>A new list containing the managed records.</returns>
    List<ParticipationRecord> GetAll();

    /// <summary>
    /// Calculates the current total represented by a student's managed records.
    /// </summary>
    /// <param name="studentId">The student identifier used to select records.</param>
    /// <returns>The sum of the point values currently reported by matching records.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the student identifier is empty.
    /// </exception>
    int GetTotalPointsForStudent(Guid studentId);

    /// <summary>
    /// Replaces the notes on one managed record.
    /// </summary>
    /// <param name="id">The identifier of the record to update.</param>
    /// <param name="notes">The replacement notes, or null.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the notes exceed the domain limit.
    /// </exception>
    void UpdateNotes(Guid id, string? notes);

    /// <summary>
    /// Removes one managed participation record.
    /// </summary>
    /// <param name="id">The identifier of the record to remove.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    void Delete(Guid id);
}
