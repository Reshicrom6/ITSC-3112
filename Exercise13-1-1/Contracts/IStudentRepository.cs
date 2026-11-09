using Exercise13_1_1.Domain;

namespace Exercise13_1_1.Contracts;

public interface IStudentRepository
{
    void Add(Student student);
    List<Student> GetAll();
}
