using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";

        Console.WriteLine("Enter your precentage in the class: ");
        string str_percentage = Console.ReadLine();
        int int_percentage = int.Parse(str_percentage);

        if (int_percentage == 90 || int_percentage > 90)
        {
            letter = "A";
        }
        else if (int_percentage == 80 || int_percentage > 80)
        {
            letter = "B";
        }
        else if (int_percentage == 70 || int_percentage > 70)
        {
            letter = "C";
        }
        else if (int_percentage == 60 || int_percentage > 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You got an {letter} in the class");
        if (int_percentage == 70 || int_percentage > 70)
        {
            Console.WriteLine("You passed the class!");
        }
        else
        {
            Console.WriteLine("You failed the class");
        }

    }
}
