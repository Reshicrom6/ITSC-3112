namespace StudentParticipationAppendix;

/// <summary>
/// A Simple Factory that chooses which enrollment source to create.
/// </summary>
public static class EnrollmentSourceFactory
{
    public static IEnrollmentSource Create(string source)
    {
        if (source == "csv")
        {
            return new CsvEnrollmentSource();
        }

        if (source == "api")
        {
            return new CanvasApiEnrollmentSource();
        }

        throw new ArgumentException(
            "Choose csv or api for the enrollment source.",
            nameof(source));
    }
}
