namespace StudentParticipationAppendix;

/// <summary>
/// Imports students by using the source created by EnrollmentSourceFactory.
/// </summary>
public abstract class EnrollmentImporter
{
    public List<Student> Import()
    {
        IEnrollmentSource source = CreateEnrollmentSource();

        List<Student> students = source.GetStudents();

        if (students.Count == 0)
        {
            throw new InvalidOperationException(
                "The demo roster must contain at least one student.");
        }

        return students;
    }
    
    protected abstract IEnrollmentSource CreateEnrollmentSource();
}
