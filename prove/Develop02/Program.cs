using System.IO;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Journel
    {
        /*This class makes a list of all the entrie that have been written. It has 3 functions, one diplpays
        the entries, another saves the journel to a text file, and the last reads a text file and loads it inro first
        the JournelEntry class and then into this class
        */
        public List<JournelEntry> _journel_entries = new List<JournelEntry>();
        public string _file_name;
        
        public void Display()
        {
    
            foreach (JournelEntry item in _journel_entries)
            {
            item.Display();
            }
        }
        
        public void SaveToFile()
        {
            List<String> EntriesToAdd = new List<String>();
            foreach (JournelEntry item in _journel_entries)
            {
            string EntryToSave = ($"{item._date}~{item._promt}~{item._response}");
            EntriesToAdd.Add(EntryToSave);
            }
            using (StreamWriter outputFile = new StreamWriter(_file_name))
            {
                foreach (string item in EntriesToAdd)
                {
                    outputFile.WriteLine(item);
                }
            }
            
        }
        
        public void ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(_file_name);

            foreach (string line in lines)
            {
                JournelEntry File_Entry = new JournelEntry();
                string[] parts = line.Split("~");

                File_Entry._date = parts[0];
                File_Entry._promt = parts[1];
                File_Entry._response = parts[2];
                _journel_entries.Add(File_Entry);
            }
        }
    }

public class JournelEntry
    {
        //This first class saves each jourel entry. It has 3 parts, the current date
        //the promt for the entry and the response to the promt
        // its only function is to display the entry

        public string _date;
        public string _promt;
        public string _response;
        public void Display()
        {
            Console.WriteLine($"Date: {_date} - Promt: {_promt} \n {_response}");
        }


    }
class Program
{ 
    static void Main(string[] args)
    {
        List<string> journel_prompts = new List<string>
        {
            "Describe a moment from today that made you smile.",
            "What are three things you are grateful for right now?",
            "Write about a challenge you faced today and how you overcame it.",
            "Reflect on a recent accomplishment and how it made you feel.",
            "Explore a goal you have for the next month and outline steps to achieve it.",
            "Describe a place that brings you peace and why it's significant.",
            "Write a letter to your future self, expressing your hopes and aspirations.",
            "What is a mistake you made recently, and what did you learn from it?",
            "Explore a book or article that has inspired you lately and explain why.",
            "List three things you love about yourself and why they are important.",
            "Reflect on a difficult conversation you had and what you learned from it.",
            "What are your favorite ways to practice self-care and why?",
            "Explore a childhood memory that still resonates with you.",
            "Write about a fear you have and how you can work to overcome it.",
            "What is a skill or hobby you would like to develop, and why?",
            "Reflect on a setback you faced and the lessons it taught you.",
            "Describe your ideal day and what activities would be involved.",
            "Write about someone who has positively impacted your life and how.",
            "Explore a recurring dream or theme in your dreams and its significance.",
            "Reflect on your priorities and whether they align with your values.",
        };
        //Here are some intial variables the program uses to function
        int user_choice = -1;                                   //the actual value of this is set by the user later
        Journel current_Journel = new Journel();                  //A Journel class is created in case none is loaded
        
        while (user_choice != 5)     //This while loop creates a menu. The program ends when the user selects option 5 from the menu
        {
            //The menus is displayed  and the user choice is read here
            Console.WriteLine("Please select one of the following:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Enter your choice: ");
            
            string str_user_choice = Console.ReadLine();
            user_choice = int.Parse(str_user_choice);

            if (user_choice == 1)
            /*This choice allows the user to wirte a new entry. The user is given a random promt and repondes to it
            the current date, promt, and user repsonse are all saved to an entry class which is added to the Journel class
            */
            {
                JournelEntry new_entry = new JournelEntry();  //A new Journel class is created
                
                //The current date is saved and formated
                DateTime current_date = DateTime.Now;
                string formated_date = current_date.ToString("MM/dd/yyyy");
                
                //A random promt is selected and displayed, the user response is saved
                Random random = new Random();
                int randomNumber = random.Next(0, 20);
                string new_promt = journel_prompts[randomNumber];
                Console.WriteLine($"{new_promt} \n");
                string new_response = Console.ReadLine();
                
                //All elements of the JournelEntry class are saved and the JournEntry is added to the list in the Journel
                new_entry._promt = new_promt;
                new_entry._response = new_response;
                new_entry._date = formated_date;
                current_Journel._journel_entries.Add(new_entry);

            }
            
            else if (user_choice == 2)
            //This choice will display all entries in the current loaded journel
            {
                current_Journel.Display();
            }
           
            else if (user_choice == 3)
            /*This choice will allow the user to laod a journel, first the user is asked for the text file name. That
            is then saved to an element in the Journel class, and then the function that reads the text file is called
            */
            {
                //these two lines of code will simply clear out what is already in the current journel class so
                //that a new journel can be loaded
                Journel File_journel = new Journel();
                current_Journel = File_journel; 

                Console.WriteLine("What is the file name? ");
                current_Journel._file_name = Console.ReadLine();
                current_Journel.ReadFile();
                Console.WriteLine("The file has been loaded");
            }
            
            else if (user_choice == 4)
            /*This choice allows will save the current journel to a text file. The user is asked for  the file name,
            which is saved in the class, and then the save to file function is called which saves the journel to that name
            */
            {
                Console.WriteLine("Enter the name you would like the file to be called: ");
                current_Journel._file_name = Console.ReadLine();
                current_Journel.SaveToFile();
                Console.WriteLine("The file has been saved!");
            }
        }

        Console.WriteLine("End of Line");
    }
}
