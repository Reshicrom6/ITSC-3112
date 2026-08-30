namespace Assignment2_2_1;

public class EquipmentCatalogue
{
    public List<Category> Categories { get; private set; }

    private List<EquipmentItem> EquipmentItems { get; set; }

    public EquipmentCatalogue()
    {
        Categories = new List<Category>();
        EquipmentItems = new List<EquipmentItem>();
    }

    public void showAvailableCategories()
    {
        foreach (Category category in Categories)
        {
            Console.WriteLine(category.Name);
        }
    }

    public void showEquipment()
    {
        foreach (EquipmentItem item in EquipmentItems)
        {
            Console.WriteLine(item.Name);
        }
    }

    public void showAvailability()
    {
        foreach (EquipmentItem item in EquipmentItems)
        {
            Console.WriteLine(item.Name + " - " + item.AvailabilityStatus);
        }
    }

    public class EquipmentItem
    {
        public string Name { get; set; }
        public string AvailabilityStatus { get; set; }

        public EquipmentItem()
        {
            Name = string.Empty;
            AvailabilityStatus = "Available";
        }
    }
}