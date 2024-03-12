using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string GetUserName()
    {
        Console.WriteLine("Enter your user name: ");
        string user_name = Console.ReadLine();
        return user_name;
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string user_name = GetUserName();
        
    }
}
