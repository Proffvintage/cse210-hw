using System.ComponentModel;
//This is the parent class to all other goal classes
class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completed = false;
    //There are two constructors, The first is used to create a new goal, the second is used to load an exsting goal
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public Goal(string name, string description, int points, bool completed)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = completed;
    }
   
   //Basic Getter that gets the name of a goal
    public string GetName()
    {
        return _name;
    }
    
    //This method is called whenever a user completes a goal, or makes progress in a goal. It is called every time record event is selected
    //Since each goal completion is handled differently, it is virtual
    public virtual int Completion()
    {
        Console.WriteLine($"You have completed this goal! You will be rewarded {_points} points\n");
        _completed = true;
        return _points;
    }
   
    //This method will display a goal and the progress of that goal. Again, sicne each goal ways to be completed this also is virtual
    public virtual void DisplayGoal()
    {
        //If the goal is completed, there is an "X" marking completion when displayed
        string X ="";
        if (_completed)
        {
            X = "X";
        }
        Console.WriteLine($"({X}) {_name}: {_description}");
    }
 
  //This method prepares the variables to be saved into a save file. It is virtual since each type of goal has different variables
    public virtual string GetStringRepresentation()
    {
        return "";
    }

}
