namespace Exercise2_2_1;

public class Category
{
    public string Name { get; set; }
    public string Description { get; private set; }
    public int StandardLoanPeriod { get; private set; }
    
    public EquipmentCatalog Catalog { get; set; }

    public Category()
    {
        Name = string.Empty;
        Description = string.Empty;
        StandardLoanPeriod = 0;
        Catalog = null;
    }

    public void ClassifyEquipment()
    {
        if (Catalog == null || string.IsNullOrWhiteSpace(Name))
        {
            return;
        }

        if (!Catalog.Categories.Contains(this))
        {
            Catalog.Categories.Add(this);
        }
    }

    public string Describe()
    {
        return Description;
    }

    public void SetStandardLoanPeriod(int days)
    {
        if (days < 0)
        {
            return;
        }

        StandardLoanPeriod = days;
    }
}