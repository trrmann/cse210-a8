class Verse
{
    private List<Word> Words { get; set; }
    private char WordDelimiter { get; set; }
    public int WordCount { get { return Words.Count; } }
    public Boolean AreAllHidden
    {
        get
        {
            Boolean result = true;
            foreach (Word word in Words)
            {
                result &= word.IsHidden;
            }
            return result;
        }
    }
    public string ObjectString
    {
        get
        {
            List<string> wordList = new List<string>();
            foreach (Word word in Words)
            {
                wordList.Add(word.ObjectString);
            }
            return String.Join(" -w- ", wordList);
        }
        set
        {
            Words = new List<Word>();
            List<string> wordList = new List<string>(value.Split(" -w- "));
            foreach(string word in wordList)
            {
                Words.Add(new Word(word, true));
            }
        }
    }
    public new string ToString {
        get
        {
            List<String> words = new List<String>();
            foreach (Word word in Words)
            {
                words.Add(word.ToString);
            }
            return String.Join(WordDelimiter, words);
        }
        set
        {
            Parse(value);
        }
    }
    public Boolean IsHidden(int wordNumber)
    {
        if (wordNumber > 0 && wordNumber <= Words.Count)
        {
            return Words[wordNumber - 1].IsHidden;
        }
        return false;
    }
    public void Show(int wordNumber)
    {
        Words[wordNumber - 1].Show();
    }
    public void Hide(int wordNumber)
    {
        Words[wordNumber - 1].Hide();
    }
    public void Parse(string verse, char wordDelimiter = '\0')
    {
        if(wordDelimiter == '\0')
        {
            wordDelimiter = WordDelimiter;
        }
        string[] words = verse.Split(wordDelimiter);
        foreach (string word in words)
        {
            Word newWord = new Word("");
            newWord.Parse(word);
            Words.Add(newWord);
        }
    }
    public Verse(List<Word> words)
    {
        Words = words;
        WordDelimiter = ' ';
    }
    public Verse(string verseString, Boolean isObjectString = false)
    {
        if (isObjectString)
        {
            ObjectString = verseString;
        }
        else
        {
            ToString = verseString;
        }
        WordDelimiter = ' ';
    }
    public void HideInelligible()
    {
        foreach(Word word in Words)
        {
            if(!word.IsElligible())
            {
                word.Hide();
            }
        }
    }
    public List<int> GetElligibleWordNumbers()
    {
        List<int> indexes = new List<int>();
        for(int c=0; c<Words.Count; c++)
        {
            if (Words[c].IsElligible() && !Words[c].IsHidden)
            {
                indexes.Add(c+1);
            }
        }
        return indexes;
    }
}
