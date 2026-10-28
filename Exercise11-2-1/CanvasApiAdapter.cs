namespace StudentParticipationAppendix;

/// <summary>
/// TODO: Adapt SimulatedCanvasClient to the IEnrollmentSource Target.
/// </summary>
public class CanvasApiAdapter : IEnrollmentSource
{
    private readonly SimulatedCanvasClient _client;

    public CanvasApiAdapter(SimulatedCanvasClient client)
    {
        _client = client;
    }

    public List<Student> GetStudents()
    {
        List<CanvasStudentResponse> responses = _client.GetStudents();
        List<Student> students = new List<Student>();

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
