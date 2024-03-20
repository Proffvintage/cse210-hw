using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
    }
}using System;

class Program
{
    
    static void Main(string[] args)
    {
        Console.Clear();
        int i = 0;          //This will be used to keep track of how mnay activities a user has completed

        while (true)
        {
            Console.WriteLine($"You have completed {i} mindful activites so far \n");   //Activites completed displayed
            
            //Menu is diaplayed
            Console.WriteLine("Menu Options ");
            Console.WriteLine(" 1. Breathing Activity");
            Console.WriteLine(" 2. Reflecting Activity");
            Console.WriteLine(" 3. Listing Activity");
            Console.WriteLine(" 4. quit");

            //User is pompted to pick and ectivty. The choice is read
            Console.WriteLine("What is your choice? ");
            string str_user_choice = Console.ReadLine();
            int user_choice = 0;
            
            //This if statement adds a level of stress proof. Only the numbers 1-4 are excepted answers to the user choice
            //If a user enters a letter, the Pars line wouldn't work. If a user enters anything but 1-4, the completed activities tracker should not go up
            if (str_user_choice == "1" || str_user_choice == "2" || str_user_choice == "3" || str_user_choice == "4")
            {
                user_choice = int.Parse(str_user_choice);
                i++;
            }

            //If user selects Breathing activty, The Activty is made and runs
            if (user_choice == 1)
            {
                BreathingActivity Breathing = new BreathingActivity();
                Breathing.Begin();
                Breathing.Pause();
                Breathing.RunActivity();
                Breathing.End();
            }

            //If user selects Reflecting activty, The Activty is made and runs
            else if (user_choice == 2)
            {
                ReflectingActivity Reflecting = new ReflectingActivity();
                Reflecting.Begin();
                Reflecting.Pause();
                Reflecting.RunActivity();
                Reflecting.End();
            }

            //If user selects Listing activty, The Activty is made and runs
            else if (user_choice == 3)
            {
                ListingActivity Listing = new ListingActivity();
                Listing.Begin();
                Listing.Pause();
                Listing.RunActivity();
                Listing.End();
            }
            
            //If the user selects quit, the loop is broken and the program ends
            else if (user_choice == 4)
            {
                Console.WriteLine("Thank you for being mindful today!");
                break;
            }

            //If the user enters something other than 1-4, they are told they entered something wrong and are prompted to try again
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid option selected. Please pick a number between 1-4 of the following choics.");
            }
        }

    }
}
