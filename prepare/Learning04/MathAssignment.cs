using System;

public class MathAssignment : Assignment
{
    private String _textbookSection;
    private String _problems;

    public MathAssignment(String studentName, String topic, String textbookSection, String problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public String GetHomeworkList() {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}