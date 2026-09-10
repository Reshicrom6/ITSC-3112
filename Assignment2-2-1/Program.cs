namespace Exercise2_2_1;

class Program
{
    static void Main(string[] args)
    {
        
        EquipmentCatalog catalog = new EquipmentCatalog();

        
        Category cameras = new Category();
        cameras.Name = "Cameras";

        
        cameras.Catalog = catalog;
        catalog.Categories.Add(cameras);

        
        Console.WriteLine("Catalog.ShowAvailableCategories():");
        catalog.ShowAvailableCategories();

        
        Console.WriteLine("Loan period before SetStandardLoanPeriod: " + cameras.StandardLoanPeriod);
        cameras.SetStandardLoanPeriod(7);
        Console.WriteLine("Loan period after SetStandardLoanPeriod: " + cameras.StandardLoanPeriod);

        cameras.ClassifyEquipment();

        Console.WriteLine("Catalog category count: " + catalog.Categories.Count);
        Console.WriteLine("Category name: " + cameras.Name);
        Console.WriteLine("Category description: " + cameras.Describe());
        Console.WriteLine("Same catalog instance: " + (cameras.Catalog == catalog));
    }
}