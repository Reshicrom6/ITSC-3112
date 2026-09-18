namespace Exercise5_2_1.Domain;

public abstract class Person
{
    public Person(Guid id, string name, string email)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("A student identifier is required.", nameof(id));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A student name is required.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("A student email is required.", nameof(email));
        }
        Id = id;
        Name = name;
        Email = email;
    }
    /// <summary>
    /// Gets the stable identifier used by repositories.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets the person's display name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the person's email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets the person's role description
    /// </summary>
    public abstract string GetRoleDescription();
}