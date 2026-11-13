using Exercise13_2_1.Contracts;
using Exercise13_2_1.Domain;

namespace Exercise13_2_1.Service;

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
        Logger.GetInstance().Info("Student added to memory storage.");
    }

    public List<Student> GetAll()
    {
        List<Student> students = new List<Student>(_students);
        Logger.GetInstance().Info($"Retrieved {students.Count} students from memory storage.");
        return students;
    }
}
