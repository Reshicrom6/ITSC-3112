namespace Exercise5_2_1.Domain;

public class Teacher : Person
{
    public string Department { get; set; }

    public Teacher(
        string name,
        string department,
        string email,
        Guid id) : base(id, name, email)
    {
        Department = department;
    }

    public override string GetRoleDescription()
    {
        return "Teacher";
    }
}