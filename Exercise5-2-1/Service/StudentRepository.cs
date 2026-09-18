using Assignment5_2_1.Contracts;
using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Service;

/// <summary>
/// Stores students in memory and enforces unique collection membership.
/// </summary>
public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();

    /// <summary>
    /// Gets the repository's managed student collection.
    /// </summary>
    public List<Student> Students => _students;

    /// <inheritdoc />
    public void Add(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        if (_students.Any(existing => existing.Id == student.Id))
        {
            throw new InvalidOperationException($"Student {student.Id} is already managed.");
        }

        _students.Add(student);
    }

    /// <inheritdoc />
    public Student? GetById(Guid id)
    {
        return _students.Find(student => student.Id == id);
    }

    /// <inheritdoc />
    public List<Student> GetAll()
    {
        return _students;
    }

    /// <inheritdoc />
    public void UpdateName(Guid id, string newName)
    {
        Student student = _students.Find(item => item.Id == id)
            ?? throw new KeyNotFoundException($"Student {id} was not found.");

        student.Name = newName;
    }

    /// <inheritdoc />
    public void Delete(Guid id)
    {
        Student student = _students.Find(item => item.Id == id)
            ?? throw new KeyNotFoundException($"Student {id} was not found.");

        _students.Remove(student);
    }
}
