public class Scripture
{
    //This class takes a Refernece, the text for the reference, and creates a list of Words from the text
    private Reference _reference;
    private string _text;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        //This is the only construct as every scripture will need both a Reference and text from the verse or verses
        _reference = reference;
        _text = text;
        _words = GetWords();
    }
    private List<Word> GetWords()
    {
        //This function seperates the text by words, saves those words to the Word class, and returns a list of those Word classes
        List<Word> words = new List<Word>();
        string[] WordsInText = _text.Split(' '); 

        foreach(string wordInList in WordsInText)  
        {
           Word newWord = new Word(wordInList);
           words.Add(newWord);                  
        }

        return words;
    }
    public List<string> GetFullWords()
    {
        //This method gets the Word._fullWord from each Word class in the _words list and makes a new string list
        List<string> FullWords = new List<string>();
        foreach(Word word in _words)
        {
            string FullWord = word.GetFullWord();
            FullWords.Add(FullWord);
        }
        return FullWords;
    }
    public List<string> GetBlankWords()
    {   
        //This method gets the Word._blankWord from each Word class in _words and returns a string list of those blank words
        List<string> BlankWords = new List<string>();
        foreach(Word word in _words)
        {
            string BlankWord = word.GetBlankWord();
            BlankWords.Add(BlankWord);
        }
        return BlankWords;
    }
    public string GetScriptureReference()
    {
        string reference = _reference.GetReference();
        return reference;
    }
}
