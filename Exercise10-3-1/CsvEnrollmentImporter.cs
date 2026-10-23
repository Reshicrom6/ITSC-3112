namespace StudentParticipationAppendix;


public class CsvEnrollmentImporter : EnrollmentImporter
{
    protected override IEnrollmentSource CreateEnrollmentSource()
    {
        return new CsvEnrollmentSource();
    }
}
