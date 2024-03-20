using System.Dynamic;

public class Word
{  
    //This class holds every word in a text of scripture. It saves the word with the letters labeled "full word",
    //and a word that has x amount of "_" for x amount of characters in the word labeled "blank word"
    private string _fullWord;
    private string _blankWord;
    public Word(string word)
    {
        _fullWord = word;
        _blankWord = CreateBlankWord();
    }

    private string CreateBlankWord()
    {   
        //This private method finds the full word's length and creates a new string of "_" as long as the word to be the blank word
        int wordLength = _fullWord.Length;
        string blankWord = new string('_', wordLength);
       
        return blankWord;
    }

    public string GetFullWord()
    {
        return _fullWord;
    }
    
    public string GetBlankWord()
    {
        return _blankWord;
    }

}
