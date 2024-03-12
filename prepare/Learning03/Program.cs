using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Fraction F1 = new Fraction();
        Fraction F5 = new Fraction(5);
        Fraction F3o4 = new Fraction (3,4);

        double one_deci = F1.GetFractionValue();
        string one_str = F1.GetFractionString();
        Console.WriteLine(one_deci);
        Console.WriteLine(one_str);

        double five_deci = F5.GetFractionValue();
        string five_str = F5.GetFractionString();
        Console.WriteLine(five_deci);
        Console.WriteLine(five_str);

        double three_fourths_deci = F3o4.GetFractionValue();
        string three_fourths_str = F3o4.GetFractionString();
        Console.WriteLine(three_fourths_deci);
        Console.WriteLine(three_fourths_str);



    }
}
