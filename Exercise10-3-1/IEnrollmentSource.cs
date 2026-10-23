namespace StudentParticipationAppendix;

/// <summary>
/// Defines a source that can provide students to the application.
/// </summary>
public interface IEnrollmentSource
{
    List<Student> GetStudents();
}
