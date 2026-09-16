namespace Exercise5_1_1;

public class ComputerLab : CampusSpace
{
    public int ComputerCount { get; }

    public ComputerLab(
        string spaceCode,
        string name,
        int capacity,
        int computerCount)
        : base(spaceCode, name, capacity)
    {
        if (computerCount <= 0 || computerCount > Capacity)
        {
            throw new ArgumentOutOfRangeException(
                nameof(computerCount),
                "Computer count must be between 1 and the space capacity.");
        }

        ComputerCount = computerCount;
    }

    public override int GetMaximumReservationHours()
    {
        return 4;
    }
}
