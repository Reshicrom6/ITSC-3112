namespace StudentParticipationAppendix;

/// <summary>
/// The Client that imports students through the IEnrollmentSource Target.
/// </summary>
public class EnrollmentImporter
{
    public List<Student> Import(IEnrollmentSource source)
    {
        ArgumentNullException.ThrowIfNull(source);

        List<Student> students = source.GetStudents();

        if (students.Count == 0)
        {
            throw new InvalidOperationException(
                "The demo roster must contain at least one student.");
        }

        return students;
    }
}
