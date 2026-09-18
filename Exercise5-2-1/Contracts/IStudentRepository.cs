using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Contracts;

/// <summary>
/// Defines in-memory CRUD operations for students.
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Adds one student while preserving identifier uniqueness.
    /// </summary>
    /// <param name="student">The valid student to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the student is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the identifier is already managed.
    /// </exception>
    void Add(Student student);

    /// <summary>
    /// Finds a student by identifier.
    /// </summary>
    /// <param name="id">The identifier to locate.</param>
    /// <returns>The matching student, or null when the identifier is not managed.</returns>
    Student? GetById(Guid id);

    /// <summary>
    /// Gets all managed students.
    /// </summary>
    /// <returns>The managed student list.</returns>
    List<Student> GetAll();

    /// <summary>
    /// Changes the name of one managed student.
    /// </summary>
    /// <param name="id">The identifier of the student to update.</param>
    /// <param name="newName">The replacement name.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    void UpdateName(Guid id, string newName);

    /// <summary>
    /// Removes one managed student.
    /// </summary>
    /// <param name="id">The identifier of the student to remove.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    void Delete(Guid id);
}
