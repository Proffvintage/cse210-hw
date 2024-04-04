class Circle : Shape
{
    private double _radius;
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double getArea()
    {
        return Math.PI * _radius * _radius;
    }
}
