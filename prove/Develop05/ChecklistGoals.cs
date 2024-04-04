class ChecklistGoal : Goal
{
    private int _timesRepeated;
    private int _timesCompleted = 0;
    private int _bonusPoints;

    //There are two constructors, The first constructor is used when the goal is being made. It does not take in a times completed value
    public ChecklistGoal(string name, string description, int points, int timesRepeated, int bonus) : base(name, description, points)
    {
        _timesRepeated = timesRepeated;
        _bonusPoints = bonus;
    }
    //The second constructor is used when a goal is loaded in. It does take a times completed value and a boolean value for completion
    public ChecklistGoal(string name, string description, int points, bool completed, int timesRepeated, int timesCompleted, int bonus) : base(name, description, points, completed)
    {
        _timesRepeated = timesRepeated;
        _timesCompleted = timesCompleted;
        _bonusPoints = bonus;
    }
   
   //This method is ovveriden to dislay the progress on this goal
    public override void DisplayGoal()
    {
        string X ="";
        if (_completed)
        {
            X = "X";
        }
            Console.WriteLine($"({X}) {_name}: {_description} ({_timesCompleted}/{_timesRepeated})");
    }
   
    //This method prepares the variables of the goal into a single string to be saved to a txt file
    public override string GetStringRepresentation()
    {
        return $"CG| {_name}| {_description}| {_points}| {_completed}| {_timesRepeated}| {_timesCompleted}| {_bonusPoints}";
    }

    //This goal is only completed when all the times repeated are complete
    //This method checks to see if all times repeated are complete, if so, the points are returned if not, 0 points are returned
    public override int Completion()
    {
        if (_completed)
        {
            Console.WriteLine("This goal has already been completed");
            return 0;
        }
        else
        {
            _timesCompleted = _timesCompleted + 1;
            if(_timesCompleted == _timesRepeated)
            {
                Console.WriteLine($"You have completed this goal! You will be rewarded {_points} points + {_bonusPoints} points for completion\n");
                _completed = true;
                return _points + _bonusPoints;
            }
            else
            {
                Console.WriteLine($"Progress on goal: {_timesCompleted}/{_timesRepeated}. You are rewarded {_points} points for your progress.");
                return _points;
            }
        }
    }
}
