using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment MarksonMath = new MathAssignment("Samuel Markson", "Math 215","Section 7","Problem 7-21");
        WrittingAssignment JakeWritting = new WrittingAssignment("Markson Samuel", "ENG 105", "The Pros and Cons of Tobacco");
        Console.WriteLine(JakeMath.getSummary());
        Console.WriteLine(JakeMath.getMathHomeWork());
        Console.WriteLine(JakeWritting.getSummary());
        Console.WriteLine(JakeWritting.getWrittingInformation());
    }
}
