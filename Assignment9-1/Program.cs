using Assignment9_1.Service;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("STUDENT PARTICIPATION MANAGEMENT SYSTEM");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine();
        Console.WriteLine("Assignment 9-1 starter loaded.");
        Console.WriteLine("Complete the login TODOs, then uncomment the code below.");

         
         StaffRepository staffRepository = new();
         AuthService authService = new(staffRepository);
         ConsoleUI consoleUi = new(authService);

         consoleUi.RunLogin();
         
    }
}
