public class Reference
{
    private string _book;
    private int _chapter;
    private int _startingVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse) //This Construct is for a single verse Reference
    {
        _book = book;
        _chapter = chapter;
        _startingVerse = verse;
        _endVerse = 0;          //Setting the endverse to 0 is used in the Get Reference method latter
    }

    public Reference(string book, int chapter, int startVerse, int endVerse) //This Construct is for a multi verse Reference
    {
        _book = book;
        _chapter = chapter;
        _startingVerse = startVerse;
        _endVerse = endVerse; 
    }

    public string GetReference()
    {
        string reference;

        //This if statment switches the format for either  a single or multi verse reference
        if (_endVerse == 0)  //The end verse is set to 0 if there is 1 verse, so this formats a single verse reference
        {
            reference = $"{_book} {_chapter}: {_startingVerse}";
        }
        else   //This formats a multi verse reference
        {
           reference = $"{_book} {_chapter}: {_startingVerse} - {_endVerse}"; 
        }
        return reference;
    }

    
}
