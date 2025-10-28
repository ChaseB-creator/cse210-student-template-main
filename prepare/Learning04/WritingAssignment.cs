public class writingAssignment : Assignments
{
    private string _title;

    public writingAssignment(string studentName, string topic, string title)

        : base(studentName, topic)
    {
        _title = title;
    }
    
    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }

}