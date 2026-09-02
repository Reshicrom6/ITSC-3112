namespace Exercise3_1_1;

public class Student
{
    public string FirstName { get; }
    public string LastName { get; }
    public string StudentId { get; }
    public string Email { get; }

    public Student (string firstName, string lastName, string studentId, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required");
        
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required");
        
        if (studentId.Length != 9)
            throw new ArgumentOutOfRangeException(studentId);
        
        if (!studentId.StartsWith("800"))
            throw new ArgumentException("Student id must start with '800'");
        
        if (Int64.TryParse(studentId, out long id))
            throw new ArgumentException("All characters in student id must be numbers");
        
        if (!email.EndsWith("@charlotte.edu"))
            throw new ArgumentException("Email address must end with '@charlotte.edu'");
        
        FirstName = firstName;
        LastName = lastName;
        StudentId = studentId;
        Email = email;
    }
}