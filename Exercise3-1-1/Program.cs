namespace Exercise3_1_1;

class Program
{
    static void Main(string[] args)
    {
        var FirstName = "";
        var LastName = "";
        var Id = "";
        var Email = "";
        var ActionChoice = 0;
        Console.WriteLine("Please enter the first name of the student:");
        FirstName = Console.ReadLine();
        Console.WriteLine("Please enter the last name of the student:");
        LastName = Console.ReadLine();
        Console.WriteLine("Please enter the id of the student:");
        Id = Console.ReadLine();
        Console.WriteLine("Please enter the email of the student:");
        Email = Console.ReadLine();
        
        Student Student = new Student(FirstName, LastName, Id, Email);
        
        Console.WriteLine("\nParticipation Actions:");
        Console.WriteLine("1. Attended Class - maximum 2 points");
        Console.WriteLine("2. Attended Office Hours - maximum 5 points");
        Console.WriteLine("3. Answered Questions in Class - maximum 3 points");
        Console.WriteLine("4. Contributed to Canvas Discussion  - maximum 3 points");
        
        Console.WriteLine("\nEnter the action number:");
        ActionChoice = Convert.ToInt32(Console.ReadLine());
        
        StudentParticipation participation = new StudentParticipation(Student, ActionChoice);
        
        Console.WriteLine("\nParticipation Record");
        Console.WriteLine("Student: " + participation.StudentInfo.FirstName  + " " + participation.StudentInfo.LastName);
        Console.WriteLine("Student ID: " + participation.StudentInfo.StudentId);
        Console.WriteLine("Student Email: " + participation.StudentInfo.Email);
        Console.WriteLine("Action: " + participation.ActionName);
        Console.WriteLine("Maximum Points: " + participation.MaximumPoints);
        Console.WriteLine("Points Earned: " + participation.PointsEarned);

        Console.WriteLine("\nEnter points for update:");
        participation.UpdatePoints(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Points Earned: " + participation.PointsEarned);
    }
}