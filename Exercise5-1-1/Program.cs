namespace Exercise5_1_1;

public static class Program
{
    public static void Main()
    {
        List<CampusSpace> spaces =
        [
            new StudyRoom(
                "ROOM-214",
                "Collaborative Study Room",
                8,
                true),
            new ComputerLab(
                "LAB-310",
                "Advanced Computing Lab",
                30,
                24),
            new DisplayGallery(
                "GAL-100",
                "Student History Gallery",
                40,
                "Computing Through the Decades")
        ];

        Console.WriteLine("Starter campus-space hierarchy");
        Console.WriteLine("------------------------------");

        foreach (CampusSpace space in spaces)
        {
            int hours = space.GetMaximumReservationHours();
            space.Reserve();

            Console.WriteLine(
                $"{space.SpaceCode}: maximum hours = {hours}, " +
                $"reserved after Reserve() = {space.IsReserved}");
        }
    }
}
