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

        foreach (ReservableSpace space in spaces)
        {
            int hours = space.GetMaximumReservationHours();
            space.Reserve();

            Console.WriteLine(
                $"{space.SpaceCode}: maximum hours = {hours}, " +
                $"reserved after Reserve() = {space.IsReserved}");

            space.Release();
            Console.WriteLine(
                $"{space.SpaceCode}: reserved after Release() = {space.IsReserved}");
        }
        Console.WriteLine($"{campusSpace.SpaceCode}: {campusSpace.Name}");
    }
}
