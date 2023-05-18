class Verses
{
    private List<Verse> VerseList { get; set; }
    private char VerseDelimiter { get; set; }
    public Boolean AreAllHidden
    {
        get
        {
            Boolean result = true;
            foreach (Verse verse in VerseList)
            {
                result &= verse.AreAllHidden;
            }
            return result;
        }
    }
    public int VerseCount
    {
        get { return VerseList.Count; }
    }
    public int WordCount
    {
        get
        {
            int result = 0;
            foreach (Verse verse in VerseList) { result += verse.WordCount; }
            return result;
        }
    }
    public string ObjectString
    {
        get
        {
            List<string> verseList = new List<string>();
            foreach (Verse verse in VerseList)
            {
                verseList.Add(verse.ObjectString);
            }
            return String.Join(" -v- ", verseList);
        }
        set
        {
            VerseList = new List<Verse>();
            List<string> verseList = new List<string>(value.Split(" -v- "));
            foreach (string verse in verseList)
            {
                VerseList.Add(new Verse(verse, true));
            }
        }
    }
    public new string ToString
    {
        get
        {
            List<string> verses = new List<string>();
            foreach (Verse verse in VerseList)
            {
                verses.Add(verse.ToString);
            }
            return String.Join(VerseDelimiter, verses);
        }
        set
        {
            Parse(value);
        }
    }
    public Verses(List<Verse> verses)
    {
        VerseList = verses;
        VerseDelimiter = '\n';
    }
    public Verses(string versesString, Boolean isObjectString = false)
    {
        if (isObjectString)
        {
            ObjectString = versesString;
        }
        else
        {
            ToString = versesString;
        }
        VerseDelimiter = '\n';
    }
    public int VerseWordCount(int verseNumber)
    {
        if (verseNumber > 0 && verseNumber <= VerseList.Count)
        {
            return VerseList[verseNumber - 1].WordCount;
        }
        return 0;
    }
    public Boolean VerseAreAllHidden(int verseNumber)
    {
        if (verseNumber > 0 && verseNumber <= VerseList.Count)
        {
            return VerseList[verseNumber - 1].AreAllHidden;
        }
        return false;
    }
    public Boolean IsHidden(int verseNumber, int wordNumber)
    {
        if (verseNumber > 0 && verseNumber <= VerseList.Count)
        {
            return VerseList[verseNumber - 1].IsHidden(wordNumber);
        }
        return false;
    }
    public void Show(int verseNumber, int wordNumber)
    {
        if (verseNumber > 0 && verseNumber <= VerseList.Count)
        {
            VerseList[verseNumber - 1].Show(wordNumber);
        }
    }
    public void Hide(int verseNumber, int wordNumber)
    {
        if (verseNumber > 0 && verseNumber <= VerseList.Count)
        {
            VerseList[verseNumber - 1].Hide(wordNumber);
        }
    }
    public string ToLabeledString(Reference reference)
    {
        List<string> verses = new List<string>();
        int counter = 0;
        foreach (Verse verse in VerseList)
        {
            verses.Add(reference.LabelVerse(counter, verse.ToString));
            counter++;
        }
        return String.Join(VerseDelimiter, verses);
    }
    public void ParseLabeledString(Reference reference, string verses, char verseDelimiter = '\0')
    {
        if (verseDelimiter == '\0')
        {
            verseDelimiter = VerseDelimiter;
        }
        string[] lines = verses.Split(verseDelimiter);
        int counter = 0;
        foreach (string line in lines)
        {
            Verse newVerse = new Verse(new List<Word>());
            newVerse.Parse(reference.RemoveVerseLabel(counter, line));
            VerseList.Add(newVerse);
            counter++;
        }
    }
    public void Parse(string verses, char verseDelimiter = '\0')
    {
        if (verseDelimiter == '\0')
        {
            verseDelimiter = VerseDelimiter;
        }
        string[] lines = verses.Split(verseDelimiter);
        foreach (string line in lines)
        {
            Verse newVerse = new Verse(new List<Word>());
            newVerse.Parse(line);
            VerseList.Add(newVerse);
        }
    }
    public void HideWords()
    {
        int verseIndex;
        List<int> elligibleWordIndexes;
        Random random = new Random();
        int maxHideTargetWordCount = (int)((double)WordCount * .20);
        if (maxHideTargetWordCount < 1)
        {
            maxHideTargetWordCount = 1;
        }
        foreach (Verse verse in VerseList)
        {
            verse.HideInelligible();
        }
        int numWordsToHide = random.Next(1, maxHideTargetWordCount);
        for (int wordsHidden = 0; (wordsHidden < numWordsToHide) && (!AreAllHidden); wordsHidden++)
        {
            verseIndex = random.Next(1, VerseList.Count+1)-1;
            elligibleWordIndexes = VerseList[verseIndex].GetElligibleWordNumbers();
            if(elligibleWordIndexes.Count>0)
            {
                VerseList[verseIndex].Hide(elligibleWordIndexes[random.Next(0, elligibleWordIndexes.Count - 1)]);
            }
            else
            {
                wordsHidden--;
            }
        }
    }
    public void ResetHidden()
    {
        foreach(Verse verse in VerseList)
        {
            for(int i = 0; i < verse.WordCount; i++)
            verse.Show(i+1);
        }
    }
    public List<string> GetVerseStringList(string verses)
    {
        string[] lines = verses.Split(VerseDelimiter);
        return new List<string>(lines);
    }
}
