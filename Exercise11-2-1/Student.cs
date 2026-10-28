namespace StudentParticipationAppendix;

public class Student
{
    public string CanvasId { get; }
    public string Name { get; }

    public Student(string canvasId, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(canvasId);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        CanvasId = canvasId;
        Name = name;
    }
}
