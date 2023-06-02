class Assignment
{
    private String _studentName;
    private String _topic;

    public Assignment(String studentName, String topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public String GetSummary() {
        return $"{_studentName} - {_topic}";
    }
}