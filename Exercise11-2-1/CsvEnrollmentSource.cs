namespace StudentParticipationAppendix;

/// <summary>
/// Reads students from the small CSV file supplied with this exercise.
/// This class already matches IEnrollmentSource and does not need an adapter.
/// </summary>
public class CsvEnrollmentSource : IEnrollmentSource
{
    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();

        string path = Path.Combine(
            AppContext.BaseDirectory,
            "data",
            "test",
            "canvas-roster.csv");

        using StreamReader reader = new StreamReader(path);
        if (reader.ReadLine() != "Student,ID")
        {
            throw new FormatException(
                "The demo CSV must start with Student,ID.");
        }

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            string[] fields = line.Split(',');
            if (fields.Length != 2 || line.Contains('"'))
            {
                throw new FormatException(
                    "Demo CSV rows need two unquoted fields: Student,ID.");
            }

            Student student = new Student(fields[1], fields[0]);
            students.Add(student);
        }

        return students;
    }
}
