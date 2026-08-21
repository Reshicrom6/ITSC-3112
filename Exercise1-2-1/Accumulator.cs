namespace Exercise1_2_1;

public class Accumulator
{
    private int _total;
    
    public int Total => _total;

    public Accumulator(int startingTotal)
    {
        _total = startingTotal;
    }

    public void Add(int amount)
    {
        _total += amount;
    }
}