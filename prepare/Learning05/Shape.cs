using System.Drawing;

class Shape
{
    private string _color;
    public Shape(string color)
    {
        _color = color;
    }
    public string getColor()
    {
        return _color;
    }
    public void _setColor(string color)
    {
        _color = color;
    }

    public virtual double getArea()
    {
        return -1;
    }
}
