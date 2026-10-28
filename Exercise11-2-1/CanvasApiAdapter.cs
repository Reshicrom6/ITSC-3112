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
        // TODO: Ask the wrapped client for CanvasStudentResponse objects.
        // TODO: Convert each response into the application's Student type.
        // TODO: Return the completed student list.
        throw new NotImplementedException(
            "Complete CanvasApiAdapter.GetStudents.");
    }
}
