using Exercise13_1_1.Contracts;
using Exercise13_1_1.Domain;

namespace Exercise13_1_1.Service;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new();

    public void Add(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        if (_students.Any(existing => existing.Id == student.Id))
        {
            throw new InvalidOperationException("The student identifier is already managed.");
        }

        _students.Add(student);
    }

    public List<Student> GetAll() => new List<Student>(_students);
}
