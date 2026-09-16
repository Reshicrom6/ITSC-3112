namespace Exercise5_1_1;

public class ReservableSpace : CampusSpace
{
    private readonly IReservationPolicy  _reservationPolicy;
    public bool IsReserved { get; private set; }

    public ReservableSpace(
        string spaceCode,
        string name,
        int capacity,
        IReservationPolicy reservationPolicy)
        : base(spaceCode, name, capacity)
    {
        if  (reservationPolicy == null)
            throw new ArgumentNullException("reservationPolicy");
        
        _reservationPolicy = reservationPolicy;
        IsReserved = false;
    }   

    public void Reserve()
    {
        if (IsReserved)
        {
            throw new InvalidOperationException(
                "A reserved space cannot be reserved again.");
        }

        IsReserved = true;
    }

    public void Release()
    {
        if (!IsReserved)
        {
            throw new InvalidOperationException(
                "An unreserved space cannot be released.");
        }

        IsReserved = false;
    }

    /// <summary>
    /// Returns the maximum number of hours this space may be reserved.
    /// A valid result is always at least one hour.
    /// </summary>
    public int GetMaximumReservationHours()
    {
        return _reservationPolicy.GetMaximumReservationHours();
    }   
}