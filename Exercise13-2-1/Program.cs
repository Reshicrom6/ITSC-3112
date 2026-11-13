using Microsoft.Data.Sqlite;
using Exercise13_2_1.Contracts;
using Exercise13_2_1.Domain;
using Exercise13_2_1.Persistence;
using Exercise13_2_1.Service;

namespace Exercise13_2_1;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Choose student storage: memory or sqlite");
        string? storageMode;
        while (true)
        {
            Console.Write("Storage: ");
            storageMode = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (storageMode is null)
            {
                return;
            }

            if (storageMode is "memory" or "sqlite")
            {
                break;
            }

            Console.Error.WriteLine("Choose memory or sqlite.");
        }

        IStudentRepository repository;
        if (storageMode == "sqlite")
        {
            DbInitializer.InitializeDatabase();
            repository = new StudentRepositoryPersisted();
        }
        else
        {
            repository = new StudentRepository();
        }

        Console.WriteLine($"STUDENT STORAGE - {storageMode.ToUpperInvariant()}");
        Console.WriteLine("Commands: add, list, quit");

        while (true)
        {
            Console.Write("\nCommand: ");
            string? command = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (command is null or "quit")
            {
                break;
            }

            try
            {
                switch (command)
                {
                    case "add":
                        string name = ReadRequired("Name: ");
                        string institutionalId = ReadRequired("Institutional ID: ");
                        Console.Write("Email (leave blank for null): ");
                        string? email = Console.ReadLine();
                        bool isActive = bool.Parse(ReadRequired("Active (true/false): "));
                        Student student = new Student(
                            Guid.NewGuid(), name, institutionalId,
                            email: email, isActive: isActive);
                        repository.Add(student);
                        Console.WriteLine($"Added: {student}");
                        break;
                    case "list":
                        List<Student> students = repository.GetAll();
                        Console.WriteLine($"Stored students: {students.Count}");
                        foreach (Student storedStudent in students)
                        {
                            Console.WriteLine(storedStudent);
                        }
                        break;
                    default:
                        Console.Error.WriteLine("Choose add, list, or quit.");
                        break;
                }
            }
            catch (Exception exception) when (
                exception is ArgumentException or FormatException or
                InvalidOperationException or SqliteException)
            {
                Console.Error.WriteLine($"Operation failed: {exception.Message}");
            }
        }
    }

    private static string ReadRequired(string prompt)
    {
        Console.Write(prompt);
        string? value = Console.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        return value.Trim();
    }
}
