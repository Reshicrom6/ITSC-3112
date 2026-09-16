namespace Exercise5_1_1;

public class DisplayGallery : CampusSpace
{
    public string ExhibitName { get; }

    public DisplayGallery(
        string spaceCode,
        string name,
        int capacity,
        string exhibitName)
        : base(spaceCode, name, capacity)
    {
        if (string.IsNullOrWhiteSpace(exhibitName))
        {
            throw new ArgumentException(
                "Exhibit name is required.",
                nameof(exhibitName));
        }

        ExhibitName = exhibitName;
    }
}
