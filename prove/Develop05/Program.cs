using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Goal> Goals = new List<Goal>();
        GoalTracker OpenedTracker = new GoalTracker(Goals, 0); //An initial Goal Tracker is made
        
        while(true)
        {
            //Main menu displays
            OpenedTracker.DisplayLevel();   //The main menu starts with your current level and points
            Console.WriteLine("Menu options:");
            Console.WriteLine(" 1. Create a new goal");
            Console.WriteLine(" 2. List goals");
            Console.WriteLine(" 3. Save goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Remove a Goal");
            Console.WriteLine(" 7. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string userChoice = Console.ReadLine();

            if(userChoice == "1")   //Add Goal selected
            {   
                Console.Clear();
                Console.WriteLine("The types of goals are:");
                Console.WriteLine(" 1. Simple Goal");
                Console.WriteLine(" 2. Eternal Goal");
                Console.WriteLine(" 3. Checklist Goal");
                Console.WriteLine("What type of goal would you like to create, or push enter to cancle: ");
                string str_goalChoice = Console.ReadLine();
                int goalChoice;
                
                //This line checks to see if an int was entered, if it was not the action is cancled and the user returns to the main menu
                //This both adds a level of stress proffing anf gives the user to option to cancle
                if (int.TryParse(str_goalChoice, out goalChoice)) 
                {
                    Console.WriteLine("What is the name of this new goal?");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("What is the desicription of this new goal? ");
                    string goalDescribtion = Console.ReadLine();
                    Console.WriteLine("How many points will this goal be worth? ");
                    int goalPoints = int.Parse(Console.ReadLine());
                    
                    Goal newGoal = new Goal("name", "descirbtion", 0);

                    if(goalChoice == 1)     //Simple Goal is created
                    {
                        newGoal = new SimpleGoal(goalName, goalDescribtion, goalPoints);

                    }
                    else if(goalChoice == 2)    //Eternal Goal is created
                    {
                        newGoal = new EternalGoal(goalName, goalDescribtion, goalPoints);
                    }
                    else if(goalChoice == 3)    //Checklist Goal is created
                    {
                        Console.WriteLine("How many times will this goal be repeatead?");
                        int timesRepeated = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the bonus for completed this goal? ");
                        int bonus = int.Parse(Console.ReadLine());
                        newGoal = new ChecklistGoal(goalName, goalDescribtion, goalPoints, timesRepeated, bonus);
                    }
                    OpenedTracker.AddGoal(newGoal);     //The goal that was created is added to the Tracker
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Action Cancled\n");
                }
            }
            else if(userChoice == "2")  //Dislpayed Goal selected
            {
                OpenedTracker.DisplayGoals();  
            }
            else if(userChoice == "3")  //Save Goals selected
            {
                OpenedTracker.Save();   
            }
            else if(userChoice == "4")  //Load Goals selected
            {
                OpenedTracker.Load();
            }
            else if(userChoice == "5")  //Record Event selected
            {
                OpenedTracker.RecordEvent();
            }
            else if(userChoice == "6")  //Remove Goal Selected. This is a feature I added
            {
                OpenedTracker.RemoveGoal(); //The method is called from the Goal Tracker class. The user selects a goal to be removed from the tracker
            }
            else if(userChoice == "7")  //Quit selected
            {
                break;
            }
            else    //A layer of stress proofing. When the user inputs a invalid answer this error is displayed
            {
                Console.WriteLine("That was not a valid entery, please pick a nummber from 1-7");
            }
        }
    }
}
