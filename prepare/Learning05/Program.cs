using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {

        Square box = new Square("blue", 3);
        Rectangle rect = new Rectangle("red", 3, 2);
        Circle round = new Circle("yellow", 1);

        List<Shape> shapes = new List<Shape>{box, rect, round};

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.getColor());
            Console.WriteLine(s.getArea());
        }
    }
}
