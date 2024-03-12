using System;

class Program
{

    static void Main(string[] args)
    {
        int guess_counter = 1;
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 101);

        Console.WriteLine("Guess a number: ");
        string str_user_guess = Console.ReadLine();
        int user_guess = int.Parse(str_user_guess);

        while (user_guess !=  magic_number)
        {
            if (magic_number > user_guess)
            {
                Console.WriteLine("Higher");
            }
            if (magic_number < user_guess)
            {
                Console.WriteLine("Lower");
            }
            Console.WriteLine("Guess a number: ");
            str_user_guess = Console.ReadLine();
            user_guess = int.Parse(str_user_guess);
            guess_counter ++;
        }

        Console.WriteLine("That's the number!");
        Console.WriteLine($"It took you {guess_counter} guesses.");

    }
}
