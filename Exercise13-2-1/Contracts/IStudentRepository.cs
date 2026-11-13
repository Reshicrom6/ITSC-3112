using Exercise13_2_1.Domain;

namespace Exercise13_2_1.Contracts;

public interface IStudentRepository
{
    void Add(Student student);
    List<Student> GetAll();
}
