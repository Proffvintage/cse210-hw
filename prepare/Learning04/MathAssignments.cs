public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;
    private string _name = "name";
    public MathAssignment(string name, string topic, string textbookSection, string problems) : base(name,topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    
    }
    public string getMathHomeWork()
        {
            return _textbookSection + " " + _problems;
        }
}
