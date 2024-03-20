using System.Threading.Tasks.Dataflow;

class Activity
{
    private string _name;
    private string _describtion;
    protected int _duration;
    //The pause symbols list will be iterated through whenever there is a pause to be done. It creates a rotating animation
    protected List<string> PauseSymbols = new List<string>{"|","\\","-","/","|","\\","-","/",}; 

    protected Activity(string name, string description)
    {
        _name = name;
        _describtion = description;
    }

    public void Begin()
    {
        //This method displayes the name and describtion of the actvity. It also gets the duration from the user
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_describtion);
        Console.WriteLine("\nHow many second would you like the activity to last?");
        string str_duration = Console.ReadLine();
        int duration = int.Parse(str_duration);
        _duration = duration;
    }
    public void Pause()
    {
        //This method gives the user a breif paus between selecting the Activity and starting
        Console.Clear();
        Console.WriteLine("Get Ready ...");

        //The pause symbols are iterated through to creat a roating animation. There is time between each symbol
        foreach (string s in PauseSymbols)
        {
            Console.Write(s);
            Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }
    public void End()
    {
        //In this method, there is a completion string displayed and the pause animation is again given
        Console.WriteLine($"\nYou have completed a {_duration} second {_name}");
        foreach (string s in PauseSymbols)
        {
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        Console.Clear();
    }


}
