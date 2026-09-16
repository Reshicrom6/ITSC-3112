namespace Exercise5_1_1;

public class CampusSpace
{
    public string SpaceCode { get; }
    public string Name { get; }
    public bool IsReserved { get; private set; }
    protected int Capacity { get; }

    public CampusSpace(
        string spaceCode,
        string name,
        int capacity)
    {
        if (string.IsNullOrWhiteSpace(spaceCode))
        {
            throw new ArgumentException(
                "Space code is required.",
                nameof(spaceCode));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Name is required.",
                nameof(name));
        }

        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(capacity),
                "Capacity must be positive.");
        }

        SpaceCode = spaceCode;
        Name = name;
        Capacity = capacity;
        IsReserved = false;
    }

    
}
