ublic class Assignment
{
    private string _name;
    private string _topic;
    public Assignment(string name, string topic)
    {
        _name = name;
        _topic = topic;
    }

    public string getSummary()
    {
        return _name + " - " + _topic;
    }
    public string getName()
    {
        return _name;
    }
}
