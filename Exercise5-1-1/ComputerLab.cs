namespace Exercise5_1_1;

public class ComputerLab : ReservableSpace
{
    public int ComputerCount { get; }

    public ComputerLab(
        string spaceCode,
        string name,
        int capacity,
        int computerCount,
        IReservationPolicy reservationPolicy)
        : base(spaceCode, name, capacity, reservationPolicy)
    {
        if (computerCount <= 0 || computerCount > Capacity)
        {
            throw new ArgumentOutOfRangeException(
                nameof(computerCount),
                "Computer count must be between 1 and the space capacity.");
        }

        ComputerCount = computerCount;
    }
    
}
