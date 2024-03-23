using System.Diagnostics.CodeAnalysis;

class ReflectingActivity: Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity():
    base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string> { "Think of a time you helped someone or made a difference in their life.", "Think of a time you made a positive change in your life.", "Think of a time you accomplsihed something relly difficult.", "Think of a time where you felt happier than ever", "Think of an exsperience that grew your testimony","Think of an exsperience where you felt loved" };
        _questions = new List<string> { "Why is this exspierence meaningful to you?", "How did you feel during this exspierence?", "What can you learn from this exsperience?", "How do you think this exsperience has affected your life?", "How has exspereince affected others involved in it?","What is your favorite thing about this experience?","How can you keep this experience in mind in the future?","Why was this experience meaningful to you?" };

    }

    public void RunActivity()
    {
        //This method gives a random exspereince (prompt) for the user to reflect, and then asks the user to ponder specific questions about that exsperience
        //The code is written so the same question will not be asked more than once

        Random rand = new Random();
        int promptSelection = rand.Next(0, _prompts.Count);
        string prompt = _prompts[promptSelection];
        Console.WriteLine("Consider the following prompt:\n ");
        Console.WriteLine(prompt);
        Console.WriteLine("\nWhen you have thought of an expereince, press enter");
        Console.ReadLine();
        
        //This for loop completely randomizes the question list. Late, the list is simply iterated though starting from 0.
        //It will continue to iterat until the duration is up. Doing it this way prevents the same question from being asked more than once
        for (int i = _questions.Count - 1; i > 0; i--)
            {   
                int j = rand.Next(0, i + 1);
                string temp = _questions[i];
                _questions[i] = _questions[j];
                _questions[j] = temp;
            }

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int k = 0;      //This integer is what will be used to iterat through the list of questions

        while (DateTime.Now < endTime)
        {
            string question = _questions[k];
            Console.WriteLine(question);

            //The pause animation is called here. This one is slower, giving the user 10 seconds to think about the question
            foreach (string s in PauseSymbols)
            {
                Console.Write(s);
                Thread.Sleep(1250);
                Console.Write("\b \b");
            }
            Console.WriteLine("\n \n");
            k++;

            //This if statemnt ensures that the activity will end if all questions in the list have been asked
            if(k >= _questions.Count)
            {
                break;
            }
        }
    }
}
