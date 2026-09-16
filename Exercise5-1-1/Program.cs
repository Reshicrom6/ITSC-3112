namespace Exercise5_1_1;

public static class Program
{
    public static void Main()
    {
        DisplayGallery gallery = new DisplayGallery(
            "GALLERY-101",
            "Main Display Gallery",
            40,
            "Spring Exhibition");

        CampusSpace campusSpace = gallery;

        List<CampusSpace> spaces =
        [
            new StudyRoom("ROOM-214", "Collaborative Study Room", 8, true, 
                new FixedReservationPolicy(2)),
            new ComputerLab("LAB-310", "Advanced Computing Lab", 30, 24,
                new FixedReservationPolicy(4))
        ];
        Console.WriteLine("Starter campus-space hierarchy");
        Console.WriteLine("------------------------------");
        foreach (ReservableSpace space in spaces)
        {
            int hours = space.GetMaximumReservationHours();
            bool wasReservedBeforeReserve = space.IsReserved;
            space.Reserve();
            bool isReservedAfterReserve = space.IsReserved;

            space.Release();
            bool isReservedAfterRelease = space.IsReserved;

            Console.WriteLine(
                $"{space.SpaceCode}: maximum hours = {hours}, " +
                $"reserved before Reserve() = {wasReservedBeforeReserve}, " +
                $"reserved after Reserve() = {isReservedAfterReserve}, " +
                $"reserved after Release() = {isReservedAfterRelease}");
        }
        
        
        Console.WriteLine($"{campusSpace.SpaceCode}: {campusSpace.Name}");
    }
}
