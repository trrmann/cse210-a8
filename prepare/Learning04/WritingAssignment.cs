
using System;

public class WritingAssignment : Assignment
{
    private String _title;

    public WritingAssignment(String studentName, String topic, String title) : base(studentName, topic)
    {
        _title = title;
    }

    public String GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}