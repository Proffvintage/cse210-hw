using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment JakeMath = new MathAssignment("Jacob Lamb", "Math 215","Section 7","Problem 7-21");
        WrittingAssignment JakeWritting = new WrittingAssignment("Jacob Lamb", "ENG 105", "The Pros and Cons of medical marijuana");
        Console.WriteLine(JakeMath.getSummary());
        Console.WriteLine(JakeMath.getMathHomeWork());
        Console.WriteLine(JakeWritting.getSummary());
        Console.WriteLine(JakeWritting.getWrittingInformation());
    }
}
