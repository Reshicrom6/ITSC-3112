namespace Exercise3_1_1;

public class StudentParticipation
{
    public Student StudentInfo { get; }
    public string ActionName { get; }
    public int MaximumPoints { get; }
    public int PointsEarned { get; private set; }

    private void SetActionChoiceMapping(int actionChoice, out string actionName, out int maximumPoints)
    {
        switch (actionChoice)
        {
            case 1:
                actionName = "Attended Class";
                maximumPoints = 1;
                break;
            case 2:
                actionName = "Attended office hours";
                maximumPoints = 2;
                break;
            case 3:
                actionName = "Answered Questions in Class";
                maximumPoints = 3;
                break;
            case 4:
                actionName = "Contributed to Canvas Discussion";
                maximumPoints = 2;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(actionChoice));
        }
    }

    public StudentParticipation(Student student, int actionChoice)
    {
        if (student is null)
            throw new ArgumentNullException(nameof(student));

        if (actionChoice < 1 || actionChoice > 4)
            throw new ArgumentOutOfRangeException(nameof(actionChoice));

        SetActionChoiceMapping(actionChoice, out string actionName, out int maximumPoints);

        StudentInfo = student;
        ActionName = actionName;
        MaximumPoints = maximumPoints;
        PointsEarned = 0;
    }

    public void UpdatePoints(int newPoints)
    {
        if (newPoints < 0 || newPoints > MaximumPoints)
            throw new ArgumentOutOfRangeException(nameof(newPoints));
        
        PointsEarned = newPoints;
    }
    
    
    
}