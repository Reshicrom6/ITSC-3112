namespace StudentParticipationAppendix;

/// <summary>
/// Gets students from the simulated Canvas API client.
/// </summary>
public class CanvasApiEnrollmentSource : IEnrollmentSource
{
    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();

        SimulatedCanvasClient client = new SimulatedCanvasClient();
        List<CanvasStudentResponse> responses = client.GetStudents();

        foreach (CanvasStudentResponse response in responses)
        {
            Student student = new Student(
                response.Id.ToString(),
                response.Name);

            students.Add(student);
        }

        return students;
    }
}
