namespace Exercise2_2_1;

public class EquipmentCatalog
{
    public List<Category> Categories { get; private set; }

    private List<EquipmentItem> EquipmentItems { get; set; }

    public EquipmentCatalog()
    {
        Categories = new List<Category>();
        EquipmentItems = new List<EquipmentItem>();
    }

    public void ShowAvailableCategories()
    {
        foreach (Category category in Categories)
        {
            Console.WriteLine(category.Name);
        }
    }

    public void ShowEquipment()
    {
        foreach (EquipmentItem item in EquipmentItems)
        {
            Console.WriteLine(item.Name);
        }
    }

    public void ShowAvailability()
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