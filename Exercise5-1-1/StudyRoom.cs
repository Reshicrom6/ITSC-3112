namespace Exercise5_1_1;

public class StudyRoom : CampusSpace
{
    public bool HasWhiteboard { get; }

    public StudyRoom(
        string spaceCode,
        string name,
        int capacity,
        bool hasWhiteboard)
        : base(spaceCode, name, capacity)
    {
        HasWhiteboard = hasWhiteboard;
    }

    public override int GetMaximumReservationHours()
    {
        return 2;
    }
}
