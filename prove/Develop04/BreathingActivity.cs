using System.ComponentModel;

class BreathingActivity: Activity
{
    public BreathingActivity():
    base("Beathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."){}

    public void RunActivity()
    {
        //This method has the user breathe in for 4 seconds and out for 4 seconds. 
        //It will keep telling the user to do so until the duration the user inputed runs out
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in for 4");
            Console.Write("\n4");
            Thread.Sleep(1000);
            Console.Write("\b \b 3");
            Thread.Sleep(1000);
            Console.Write("\b \b 2");
            Thread.Sleep(1000);
            Console.Write("\b \b 1");
            Thread.Sleep(1000);
            Console.Write("\b \b ");

            Console.Write("\nBreath out for 4");
            Console.Write("\n4");
            Thread.Sleep(1000);
            Console.Write("\b \b 3");
            Thread.Sleep(1000);
            Console.Write("\b \b 2");
            Thread.Sleep(1000);
            Console.Write("\b \b 1");
            Thread.Sleep(1000);
            Console.Write("\b \b ");
            Console.WriteLine();

        }
    }

}
