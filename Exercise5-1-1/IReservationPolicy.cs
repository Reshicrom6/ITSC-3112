namespace Exercise5_1_1;

public interface IReservationPolicy
{
    /// <summary>
    /// Gets the maximum reservation duration in hours.
    /// Every implementation returns a value of at least one hour or greater.
    /// </summary>
    int GetMaximumReservationHours();
}