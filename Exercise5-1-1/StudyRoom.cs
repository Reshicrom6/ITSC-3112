namespace Exercise5_1_1;

public class StudyRoom : ReservableSpace
{
    public bool HasWhiteboard { get; }

    public StudyRoom(
        string spaceCode,
        string name,
        int capacity,
        bool hasWhiteboard,
        IReservationPolicy reservationPolicy)
        : base(spaceCode, name, capacity, reservationPolicy)
    {
        HasWhiteboard = hasWhiteboard;
    }
}
