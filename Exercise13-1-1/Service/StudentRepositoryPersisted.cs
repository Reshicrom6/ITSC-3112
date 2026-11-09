using Microsoft.Data.Sqlite;
using Exercise13_1_1.Contracts;
using Exercise13_1_1.Domain;
using Exercise13_1_1.Persistence;

namespace Exercise13_1_1.Service;

public class StudentRepositoryPersisted : IStudentRepository
{
    public void Add(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }
        using SqliteConnection connection =
            new SqliteConnection(DbInitializer.ConnectionString);
        connection.Open();
        using SqliteCommand command = connection.CreateCommand();
        
        command.CommandText = @"
            INSERT INTO Student (
                Id, Name, InstitutionalId, CanvasUserId,
                CanvasLoginId, Pronouns, ClassStanding,
                RegistrationStatus, Email, IsActive)
            VALUES (
                $id, $name, $institutionalId, $canvasUserId,
                $canvasLoginId, $pronouns, $classStanding,
                $registrationStatus, $email, $isActive);";
        
        command.Parameters.AddWithValue("$id", student.Id.ToString());
        command.Parameters.AddWithValue("$name", student.Name);
        command.Parameters.AddWithValue(
            "$institutionalId",
            (object?)student.InstitutionalId ?? DBNull.Value);
        command.Parameters.AddWithValue(
            "$isActive", student.IsActive ? 1 : 0);
        command.Parameters.AddWithValue("$canvasUserId",
            (object?)student.CanvasUserId ?? DBNull.Value);
        command.Parameters.AddWithValue("$canvasLoginId", 
            (object?)student.CanvasLoginId ??  DBNull.Value);
        command.Parameters.AddWithValue("$pronouns",
            (object?)student.Pronouns ?? DBNull.Value);
        command.Parameters.AddWithValue("$classStanding",
            (object?)student.ClassStanding ?? DBNull.Value);
        command.Parameters.AddWithValue("$registrationStatus",
            (object?)student.RegistrationStatus ?? DBNull.Value);
        command.Parameters.AddWithValue("$email",
            (object?)student.Email ?? DBNull.Value);
        
        int rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine($"Inserted  {rowsAffected} student records");
    }

    public List<Student> GetAll()
    {
        List<Student> students = new List<Student>();
        
        using SqliteConnection connection = 
            new SqliteConnection(DbInitializer.ConnectionString);
        connection.Open();
        using  SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM Student;";
        
        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Student student = new Student(
                Guid.Parse(reader.GetString(0)),
                reader.GetString(1),
                reader.IsDBNull(2) ? null : reader.GetString(2),
                reader.IsDBNull(3) ? null : reader.GetString(3),
                reader.IsDBNull(4) ? null : reader.GetString(4),
                reader.IsDBNull(5) ? null : reader.GetString(5),
                reader.IsDBNull(6) ? null : reader.GetString(6),
                reader.IsDBNull(7) ? null : reader.GetString(7),
                reader.IsDBNull(8) ? null : reader.GetString(8),
                reader.GetBoolean(9));
            students.Add(student);
        }

        return students;
    }
}