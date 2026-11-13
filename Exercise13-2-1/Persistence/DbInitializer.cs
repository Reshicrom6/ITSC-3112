using Exercise13_2_1.Service;
using Microsoft.Data.Sqlite;

namespace Exercise13_2_1.Persistence;

public static class DbInitializer
{
    public const string ConnectionString = "Data Source=app.db";

    public static void InitializeDatabase()
    {
        using SqliteConnection connection = new SqliteConnection(ConnectionString);
        connection.Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Student (
                Id TEXT PRIMARY KEY NOT NULL,
                Name TEXT NOT NULL,
                InstitutionalId TEXT,
                CanvasUserId TEXT,
                CanvasLoginId TEXT,
                Pronouns TEXT,
                ClassStanding TEXT,
                RegistrationStatus TEXT,
                Email TEXT,
                IsActive INTEGER NOT NULL DEFAULT 1
            );";
        command.ExecuteNonQuery();
        Logger.GetInstance().Info("SQLite database schema initialized.");
    }
}
