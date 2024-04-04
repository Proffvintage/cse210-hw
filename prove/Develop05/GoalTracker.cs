using System.Data;
using System.Drawing;

class GoalTracker
{
    private List<Goal> _goals;
    private int _totalPoints = 0;
    private string _filename = "";
    private string _level = "YOUNGLING";
    public GoalTracker(List<Goal> goals, int totalPoints)
    {
        _goals = goals;
        _totalPoints = totalPoints;
    }
    
    //This method is called to display the current level and points of the user
    public void DisplayLevel()
    {
        Console.WriteLine($"You are a level {_level} with {_totalPoints} points");
    }
    
    //This methof adds a goal to the goal tracker
    public void AddGoal(Goal goal)
    {
        Console.Clear();
        _goals.Add(goal);
        Console.WriteLine("The new goal has been added!\n");
    }
    
    //This method removes a goal from the goal tracker
    public void RemoveGoal()
    {
        Console.Clear();

        //A loop is used to display the current goals
        Console.WriteLine("Your Goals are: ");
        int n = 1;
        foreach(Goal g in _goals)
            {
                string goalName = g.GetName();
                Console.WriteLine($"  {n}. {goalName}");
                n = n + 1;
            }

        //The user picks the number of the goal to be removed
        Console.WriteLine("Enter the number of the goal you would like to reomve, or push enter to cancle: ");
        string str_UserChoice = Console.ReadLine();
        int userPickedGoal; 
        Console.Clear();

        //This if statement checks to see if an int was entered, if it was not the action is cancled and the user returns to the main menu
        //This both adds a level of stress proffing anf gives the user to option to cancle
        if (int.TryParse(str_UserChoice, out userPickedGoal))
        {
            int goalRemoved = userPickedGoal - 1;
            _goals.RemoveAt(goalRemoved);
            Console.WriteLine("The goal was removed\n");
        }
        else
        {
            Console.WriteLine("Action Canlced\n");
        }
    }
    
    //This methof is called when the user wants to record an event. It gets the goal that was done from the user.
    //It then records the progross on that goal, gets the points from it and adds it to the total points.
    public void RecordEvent()
    {
        Console.Clear();

        //A for loop is used to display th goals
        Console.WriteLine("Your Goals are: ");
        int n = 1;
        foreach(Goal g in _goals)
            {
                string goalName = g.GetName();
                Console.WriteLine($"  {n}. {goalName}");
                n = n + 1;
            }
        
        //The user enters the number of the goal that was done
        Console.WriteLine("Enter the number of the goal you accomplished or made progress on, or push enter to cancle: ");
        string str_UserChoice = Console.ReadLine();
        int userPickedGoal;
        Console.Clear();

        //This if statement checks to see if an int was entered, if it was not the action is cancled and the user returns to the main menu
        //This both adds a level of stress proffing anf gives the user to option to cancle
        if (int.TryParse(str_UserChoice, out userPickedGoal))
        {
            Goal goalAccomplished = _goals[userPickedGoal-1];
            int pointsEarned = goalAccomplished.Completion();
            _totalPoints = _totalPoints + pointsEarned;
        }
        else
        {
            Console.WriteLine("Action Canlced\n");
        }
        
        //Level up is called to check if the user gained enough points to change in level
        LevelUp();
    }
    
    //This method displays all goals in the Tracker along with their progress
    public void DisplayGoals()
    {
        Console.Clear();
        foreach(Goal g in _goals)
        {
            g.DisplayGoal();
        }

        //The user will be able to veiw the goals as long as they want. When Enter is pushed the goals are cleared and they are returned to the main menu
        Console.WriteLine("Push Enter to return to the Menu");
        Console.ReadLine();
        Console.Clear();
    }
    
    //This goal checks to see if the user gained enough points to level up
    public void LevelUp()
    {
        string startLevel = _level; //If the start level changes, a message is displayed telling the user they leveled up
        if(_totalPoints > 0)
        {
            _level = "PADAWAN";
        }
        if(_totalPoints > 500)
        {
            _level = "ADVANCED PADAWAN";
        }
        if(_totalPoints > 1500)
        {
            _level = "JEDI KNIGHT";
        }
        if(_totalPoints > 3000)
        {
            _level = "JEDI GENERAL";
        }
        if(_totalPoints > 5000)
        {
            _level = "JEDI MASTER";
        }
        if(_totalPoints > 7000)
        {
            _level = "MEMBER OF JEDI COUNCIL";
        }
        if(_totalPoints > 10000)
        {
            _level = "OBIWAN KENOBI";
        }
        if(_totalPoints > 15000)
        {
            _level = "ONE WITH THE FORCE";
        }

        if(startLevel != _level)
        {
            Console.WriteLine("You leveled up!");
        }
    }
    
    //All data is stored to a file
    public void Save()
    {   
        Console.Clear();
        
        //I added a feture where if a file has already been loaded or saved, the user does not have to put in the name of the file again.
        bool ChangeFileName = true;
        if(_filename != "")
        {
            Console.WriteLine("If you would like to save to the same file as before, enter 1");
            Console.WriteLine("If you would like to save to a new file, press enter: ");
            string str_fileChoice = Console.ReadLine();
            int fileChoice;
            
            //This if statement checks to see if an int was entered, if no int is entered the user will be asked for a file name
            if(int.TryParse(str_fileChoice, out fileChoice))
            {
                if (fileChoice == 1)
                {
                    ChangeFileName = false;
                }
            }
        }
        if(ChangeFileName)
        {
            Console.WriteLine("What would you like the title of this save file to be? ");
            _filename = Console.ReadLine();
        }
        using (StreamWriter outputfile = new StreamWriter(_filename))
        {
            outputfile.WriteLine(_totalPoints + "| " + _level); //The first line of the file will be the points and level of the user

            foreach(Goal g in _goals)
            {
                outputfile.WriteLine(g.GetStringRepresentation()); // Each goal is saved into the file. One line per goal
            }
        }
        Console.Clear();
        Console.WriteLine("Your progross has been saved!\n");
    }
    
    //All data is loaded from a file and saved to this Goal Tracker class
    public void Load()
    {
        Console.Clear();
        List<Goal> loadedGoals = new List<Goal>();

        Console.WriteLine("What is the name of the save file to be loaded? ");
        _filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {   
            string[] parts = line.Split("| ");

            if (parts.Count() == 2) //The first line has the points and level of the user, this if statment saves them to the apropiate variables
            {
                _totalPoints = int.Parse(parts[0]);
                _level = parts[1];
            }
            else
            {
                Goal loadedGoal = new Goal("name", "description", 0);

                //The first part of each line will be the type of goal, these if staments will take the type of goal and save them to the proper class
                if(parts[0] == "SG")
                {
                    loadedGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                }
                else if(parts[0] == "EG")
                {
                    loadedGoal = new EternalGoal(parts[1],parts[2], int.Parse(parts[3]));
                }
                else if(parts[0] == "CG")
                {
                    loadedGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]));
                }

                loadedGoals.Add(loadedGoal);
            }
        }
        _goals = loadedGoals;
        Console.Clear();
        Console.WriteLine("Your Goals have been loaded.\n");        
    }
}
