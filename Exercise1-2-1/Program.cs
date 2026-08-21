namespace Exercise1_2_1;
    
class Program
{
    static void Main(string[] args)
    {
        Accumulator accumulator = new Accumulator(10);
        
        Console.WriteLine(accumulator.Total);
        
        accumulator.Add(5);
        Console.WriteLine(accumulator.Total);
    }
}