using System;

class Program
{
    static void Main(string[] args)
    {
        int new_number = -1;
        List<int> numbers = new List<int>();

        while (new_number != 0)
        {
            Console.WriteLine("Enter a number to add to the list");
            string str_new_number = Console.ReadLine();
            new_number = int.Parse(str_new_number);
            if (new_number != 0)
            {
                numbers.Add(new_number);
            }
            

        }

        int sum = 0;
        int largest = 0;
        foreach (int number in numbers)
        {
        sum += number;
        if (number > largest)
        {
            largest = number;
        }
        }

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is {sum}.");
        Console.WriteLine($"The average is {average}.");
        Console.WriteLine($"The largest  number is {largest}.");


        
    }
}
