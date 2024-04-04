class SimpleGoal : Goal
{
    //There are two constructors, The first is used to create a new goal, the second is used to load an exsting goal
    public SimpleGoal(string name, string description, int points) : base(name, description, points){}
    public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points, completed){}
    
    //This method prepares the variables of the goal into a single string to be saved to a txt file
    public override string GetStringRepresentation()
    {
        return $"SG| {_name}| {_description}| {_points}| {_completed}";
    }
}
