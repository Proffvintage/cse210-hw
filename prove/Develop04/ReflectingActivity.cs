class ListingActivity: Activity
{   
    private List<string> _prompts;
    public ListingActivity():
    base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string> { "Who are people that you aperciate?", "What are your strenghts","How have you seen the Lord's hand in this last week?","What are you grateful for?", "What has been the highlihgt of your days this last week?","How have you been able to help others this last week?", "How have you seen answers to your prayers." };
    }

public void RunActivity()
    {   
        //This method gives a pompt of things the user could list, and then allows the user to list items until time runs out
        Random rand = new Random();
        int promptSelection = rand.Next(0, _prompts.Count);
        Console.WriteLine("List as many answer to the following prompt as you can in the time: \n");
        Console.WriteLine(_prompts[promptSelection]);
        
        //The user is given 5 seconds after the prompt is given to think of items they might list
        Console.WriteLine("\n You may begin in ");
        for (int i = 5; i > 0; i-- )
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int j = 0;      //This integer keeps track of the items listed by the user
        
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(">");
            Console.ReadLine();
            j++;
        }
        Console.WriteLine($"\nYou listed {j} things in {_duration} seconds");
    }
}
