class EternalGoal : Goal
{
    //This is the only goal that only needs one constructor becuase it is never completed
    public EternalGoal(string name, string description, int points) : base(name, description, points){}

    //This goal is never completed, so when this method is called it returns the propwer amount of points only
    public override int Completion()
    {
        Console.WriteLine($"You will be rewarded {_points} points\n");
        return _points;
    }

    //This method prepares the variables of the goal into a single string to be saved to a txt file
    public override string GetStringRepresentation()
    {
        return $"EG| {_name}| {_description}| {_points}";
    }
}
