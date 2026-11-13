using Microsoft.Data.Sqlite;
using Exercise13_2_1.Contracts;
using Exercise13_2_1.Domain;
using Exercise13_2_1.Persistence;

namespace Exercise13_2_1.Service;

public class StudentRepositoryPersisted : IStudentRepository
{
    public void Add(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        using SqliteConnection connection = new SqliteConnection(DbInitializer.ConnectionString);
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
        command.Parameters.AddWithValue("$institutionalId", (object?)student.InstitutionalId ?? DBNull.Value);
        command.Parameters.AddWithValue("$canvasUserId", (object?)student.CanvasUserId ?? DBNull.Value);
        command.Parameters.AddWithValue("$canvasLoginId", (object?)student.CanvasLoginId ?? DBNull.Value);
        command.Parameters.AddWithValue("$pronouns", (object?)student.Pronouns ?? DBNull.Value);
        command.Parameters.AddWithValue("$classStanding", (object?)student.ClassStanding ?? DBNull.Value);
        command.Parameters.AddWithValue("$registrationStatus", (object?)student.RegistrationStatus ?? DBNull.Value);
        command.Parameters.AddWithValue("$email", (object?)student.Email ?? DBNull.Value);
        command.Parameters.AddWithValue("$isActive", student.IsActive ? 1 : 0);
        command.ExecuteNonQuery();
    }

    public List<Student> GetAll()
    {
        using SqliteConnection connection = new SqliteConnection(DbInitializer.ConnectionString);
        connection.Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, Name, InstitutionalId, CanvasUserId,
                   CanvasLoginId, Pronouns, ClassStanding,
                   RegistrationStatus, Email, IsActive
            FROM Student
            ORDER BY Name, Id;";
        using SqliteDataReader reader = command.ExecuteReader();
        List<Student> students = new();
        while (reader.Read())
        {
            students.Add(new Student(
                Guid.Parse(reader.GetString(0)),
                reader.GetString(1),
                reader.IsDBNull(2) ? null : reader.GetString(2),
                canvasUserId: reader.IsDBNull(3) ? null : reader.GetString(3),
                canvasLoginId: reader.IsDBNull(4) ? null : reader.GetString(4),
                pronouns: reader.IsDBNull(5) ? null : reader.GetString(5),
                classStanding: reader.IsDBNull(6) ? null : reader.GetString(6),
                registrationStatus: reader.IsDBNull(7) ? null : reader.GetString(7),
                email: reader.IsDBNull(8) ? null : reader.GetString(8),
                isActive: reader.GetInt64(9) != 0));
        }

        return students;
    }
}
