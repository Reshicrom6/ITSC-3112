namespace StudentParticipationAppendix;

// A stand-in for an external system: no HTTP, authentication, or real student data.
public class SimulatedCanvasClient
{
    public List<CanvasStudentResponse> GetStudents()
    {
        return new List<CanvasStudentResponse>
        {
            new CanvasStudentResponse(100101, "Avery Example"),
            new CanvasStudentResponse(100102, "Blair Example"),
            new CanvasStudentResponse(100103, "Casey Example"),
            new CanvasStudentResponse(100104, "Devon Example")
        };
    }
}

// This response is external data, not our application's Student domain object.
public class CanvasStudentResponse
{
    public int Id { get; }
    public string Name { get; }

    public CanvasStudentResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
