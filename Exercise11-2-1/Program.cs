namespace StudentParticipationAppendix;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("STUDENT PARTICIPATION - ADAPTER STARTER");

        try
        {
            Console.Write("Enrollment source (csv/api): ");
            string sourceName = (Console.ReadLine() ?? string.Empty)
                .Trim()
                .ToLowerInvariant();

            IEnrollmentSource source;

            if (sourceName == "csv")
            {
                source = new CsvEnrollmentSource();
            }
            else if (sourceName == "api")
            {
                source = new CanvasApiAdapter(
                    new SimulatedCanvasClient());
            }
            else
            {
                throw new ArgumentException(
                    "Choose csv or api for the enrollment source.",
                    nameof(sourceName));
            }

            EnrollmentImporter importer = new EnrollmentImporter();
            List<Student> students = importer.Import(source);
            Console.WriteLine($"Imported {students.Count} students.");

            // All four events belong to the first student and the same UTC day.
            Student student = students[0];
            DateTime now = DateTime.UtcNow;
            List<ParticipationRecord> records = new List<ParticipationRecord>
            {
                new ParticipationRecord(student, "Question", 3, now),
                new ParticipationRecord(student, "Question", 3, now),
                new ParticipationRecord(student, "Question", 3, now),
                new ParticipationRecord(student, "Office hours", 2, now)
            };

            Console.WriteLine(
                $"Student: {student.Name} (Canvas ID {student.CanvasId})");
            Console.WriteLine($"UTC day: {now:yyyy-MM-dd}");
            Console.Write("Scoring rule (all/daily): ");
            string rule = (Console.ReadLine() ?? string.Empty)
                .Trim()
                .ToLowerInvariant();

            ParticipationCalculator calculator =
                new ParticipationCalculator();

            int creditedPoints =
                calculator.Calculate(student, records, rule);

            Console.WriteLine($"Recorded events: {records.Count}");
            Console.WriteLine(
                $"Raw points: {calculator.Calculate(student, records, "all")}");
            Console.WriteLine($"Credited points: {creditedPoints}");
            Console.WriteLine(
                "Nothing is saved. Run again to compare another source or rule.");
        }
        catch (Exception exception) when (
            exception is IOException or UnauthorizedAccessException or
            ArgumentException or InvalidOperationException or
            FormatException or OverflowException or
            NotImplementedException)
        {
            Console.Error.WriteLine(
                $"Demo stopped: {exception.Message}");
        }
    }
}
