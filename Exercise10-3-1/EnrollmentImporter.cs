namespace StudentParticipationAppendix;

/// <summary>
/// Imports students by using the source created by EnrollmentSourceFactory.
/// </summary>
public class EnrollmentImporter
{
    public List<Student> Import(string sourceName)
    {
        IEnrollmentSource source =
            EnrollmentSourceFactory.Create(sourceName);

        List<Student> students = source.GetStudents();

        if (students.Count == 0)
        {
            throw new InvalidOperationException(
                "The demo roster must contain at least one student.");
        }

        return students;
    }
}
