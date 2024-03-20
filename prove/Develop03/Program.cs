using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        while(true)
        {  

            //The code comes with 4 scirptures, the user will be given an oportunity to put in their own if requested
            Reference Ref_JohnC3V16Th17 = new Reference("John", 3, 16, 17);
            Scripture Scrip_JohnC3V16Th17 = new Scripture(Ref_JohnC3V16Th17, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved.");
            Reference Ref_EtherC12V27 = new Reference("Ehter", 12, 27);
            Scripture Scrip_EtherC12V27 = new Scripture(Ref_EtherC12V27, "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.");
            Reference Ref_DCS88V118Th119 = new Reference("Doctrine and Covenants", 88, 118, 119);
            Scripture Scrip_DCS88V118Th119 = new Scripture(Ref_DCS88V118Th119, "And as all have not faith, seek ye diligently and teach one another words of wisdom; yea, seek ye out of the best books words of wisdom; seek learning, even by study and also by faith. Organize yourselves; prepare every needful thing; and establish a house, even a house of prayer, a house of fasting, a house of faith, a house of learning, a house of glory, a house of order, a house of God.");
            Reference Ref_JamesC1V5 = new Reference("James", 1, 5);
            Scripture Scrip_JamesC1V5 = new Scripture(Ref_JamesC1V5,"If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him.");
            
            //The scriptures above are all put into this list
            List<Scripture> AllScriptures = new List<Scripture>{ Scrip_JohnC3V16Th17, Scrip_EtherC12V27, Scrip_DCS88V118Th119, Scrip_JamesC1V5};
            
            //I added an option for the user to enter their own scripture they would like to prcatice
            Console.WriteLine("If you would like to practice a specific scripture, type 'yes', or push ENTER to have one given to you");
            string enterScripture = Console.ReadLine();

            //The selected scripture will be pulled at random if the user does not have their own, otherwise it will be set to the user's scripture
            Scripture SelectedScripture; 
            if(enterScripture == "yes") 
            {
                ////If the user wants to practic their own, they enter the scripture here
                Console.WriteLine("Enter the Book of the reference: ");
                string userBook = Console.ReadLine();
                Console.WriteLine("Enter the Chapter of the reference: ");
                string strUserChapter = Console.ReadLine();
                int userChapter = int.Parse(strUserChapter);
                Console.WriteLine("Enter the first verse of the reference: ");
                string strUserFirstVerse = Console.ReadLine();
                int userFirstVerse = int.Parse(strUserFirstVerse);
                Console.WriteLine("Enter the last of the reference, or if there is only 1 verse, enter 0: ");
                string strUserSecondVerse = Console.ReadLine();
                int userSecondVerse = int.Parse(strUserSecondVerse);
                Console.WriteLine("Enter the text of the reference: ");
                string userText = Console.ReadLine();
                Reference userReference = new Reference(userBook, userChapter, userFirstVerse, userSecondVerse);
                SelectedScripture = new Scripture(userReference, userText);
            }
            else
            {
                //IF the user doesnot have a scripture, one is picked at random from the  set scriptures
                int randomNumber = random.Next(0, 4);
                SelectedScripture = AllScriptures[randomNumber];
            }

            List<string> WordsToDisplay = SelectedScripture.GetFullWords();
            List<string> BlankWords = SelectedScripture.GetBlankWords();
            string fullReference = SelectedScripture.GetScriptureReference();

            while (true)
            {   
                //The Console is cleared, the reference is displayed in full, and the text is displayed word by word
                //*Console.Clear();* This method will not work on my computer for some reason, Bro Perish  said I am good to just comment it out 
                Console.WriteLine(fullReference);
                foreach(string word in WordsToDisplay)
                {
                    Console.Write($"{word} ");
                }
                
                //The user is given the option to quit, or to remove more words
                Console.WriteLine("");
                Console.WriteLine("Type 'quit' to exit or hit ENTER to continue: ");
                string quit = Console.ReadLine();
                
                
                bool AllIsBlank = true;  //If there are not blank letter, this will be set to false and the loop continues
                for (int j = 0; j < WordsToDisplay.Count; j++) //This for loop interates through the length of the word list
                {
                    int randomOneOrTwo = random.Next(1, 3);
                    //If at any point the word that was displayed is not blank, two things happen
                    if(WordsToDisplay[j] != BlankWords[j])
                    {
                        AllIsBlank = false;         //First, the bollean term is set to false, making it so the loop does not end
                        if (randomOneOrTwo == 1)    //Second, there is a 50/50 chance that the word is made blank, so words will become blank at random
                        {
                            WordsToDisplay[j] = BlankWords[j];
                        }
                    }

                }

                //Two things can break the loop
                if(AllIsBlank)  //If all words displayed were blank
                {break;}

                if(quit == "quit")  //If the user typed 'quit'
                {break;}
            }

            //The user is given the choice to reapeat the code with a diferent scipture if they would like
            Console.WriteLine("Would you like to memorize another scripture, type 'yes', otherwise push ENTER to exit  the  program");
            string WillLoopContinue = Console.ReadLine();
            if(WillLoopContinue != "yes")
            {
                Console.WriteLine("Program ended");
                break;
            }
        }

    }
}
