namespace Exercise5_1_1;

public class FixedReservationPolicy : IReservationPolicy
{
    public int MaximumHours { get; }
    
    public FixedReservationPolicy(int maximumHours)
    {
        if (maximumHours < 1)
            throw new  ArgumentOutOfRangeException(nameof(maximumHours), "The maximum hours must be greater than zero.");
        
        MaximumHours = maximumHours;
    }

    public int GetMaximumReservationHours()
    {
        return MaximumHours;
    }
}