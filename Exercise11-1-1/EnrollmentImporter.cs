namespace StudentParticipationAppendix;

public class EnrollmentImporter
{
    public List<Student> Import(string source)
    {
        List<Student> students = new List<Student>();

        if (source == "csv")
        {
            string path = Path.Combine(AppContext.BaseDirectory,
                "data", "test", "canvas-roster.csv");
            using StreamReader reader = new StreamReader(path);
            if (reader.ReadLine() != "Student,ID")
            {
                throw new FormatException("The demo CSV must " +
                                          "start with Student, ID.");
            }

            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                string[] fields = line.Split(',');
                if (fields.Length != 2 || line.Contains('"'))
                {
                    throw new FormatException("Demo CSV rows need " + 
                                              "two unquoted fields: Student, ID.");
                }

                Student student = new Student(fields[1], fields[0]);
                students.Add(student);
            }
        }
        else if (source == "api")
        {
            SimulatedCanvasClient client = new SimulatedCanvasClient();
            List<CanvasStudentResponse> responses = client.GetStudents();
            foreach (CanvasStudentResponse response in responses)
            {
                Student student = new Student(response.Id.ToString(), 
                    response.Name);
                students.Add(student);
            }
        }
        else
        {
            throw new ArgumentException("Choose csv or api for " + 
                                        "the enrollment source.", nameof(source));
        }

        if (students.Count == 0)
        {
            throw new InvalidOperationException("The demo roster must contain at least one student.");
        }

        return students;
    }
}
