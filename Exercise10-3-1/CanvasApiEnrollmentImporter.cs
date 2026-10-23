namespace StudentParticipationAppendix;


public class CanvasApiEnrollmentImporter : EnrollmentImporter
{
    protected override IEnrollmentSource CreateEnrollmentSource()
    {
        return new CsvEnrollmentSource();
    }
}
