namespace StudentParticipationAppendix;

/// <summary>
/// The Target interface used by EnrollmentImporter.
/// </summary>
public interface IEnrollmentSource
{
    List<Student> GetStudents();
}
