class Reference
{
    private string BookChapterDelimiter {  get; set; }
    private string ChapterVersesDelimiter { get; set;}
    private string VerseDelimiter { get; set; }
    private string Book { get; set; }
    private int Chapter { get; set; }
    private int StartVerse { get; set; }
    private int EndVerse { get; set; }
    public string ObjectString
    {
        get
        {
            return $"Book - <{Book}> ," +
                $" Chapter - <{Chapter}> ," +
                $" StartVerse - <{StartVerse}> ," +
                $" EndVerse - <{EndVerse}> ," +
                $" BookChapterDelimiter - <{BookChapterDelimiter}> ," +
                $" ChapterVersesDelimiter - <{ChapterVersesDelimiter}> ," +
                $" VerseDelimiter - <{VerseDelimiter}>";
        }
        set
        {
            string[] fieldStringArray = value.Split(" , ");
            List<string> fieldStringList = new List<string>(fieldStringArray);
            List<Tuple<string,string>> fields = new List<Tuple<string,string>>();
            foreach(string fieldString in fieldStringList)
            {
                List<string> partsList = new List<string>(fieldString.Split(" - "));
                Tuple<string, string> field = new Tuple<string, string>(partsList[0], "");
                partsList.RemoveAt(0);
                field = new Tuple<string, string>(field.Item1, String.Join(" - ", partsList));
                List<string> valuesList = new List<string>(field.Item2.Split("<"));
                valuesList.RemoveAt(0);
                field = new Tuple<string, string>(field.Item1, String.Join("<", valuesList));
                valuesList = new List<string>(field.Item2.Split(">"));
                valuesList.RemoveAt(valuesList.Count-1);
                field = new Tuple<string, string>(field.Item1, String.Join(">", valuesList));
                switch (field.Item1)
                {
                    case "Book":
                        Book = field.Item2;
                        break;
                    case "Chapter":
                        Chapter = int.Parse(field.Item2);
                        break;
                    case "StartVerse":
                        StartVerse = int.Parse(field.Item2);
                        break;
                    case "EndVerse":
                        EndVerse = int.Parse(field.Item2);
                        break;
                    case "BookChapterDelimiter":
                        BookChapterDelimiter = field.Item2;
                        break;
                    case "ChapterVersesDelimiter":
                        ChapterVersesDelimiter = field.Item2;
                        break;
                    case "VerseDelimiter":
                        VerseDelimiter = field.Item2;
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public new string ToString
    {
        get
        {
            if(StartVerse == EndVerse)
            {
                return $"{Book}{BookChapterDelimiter}{Chapter}{ChapterVersesDelimiter}{StartVerse}";
            }
            else
            {
                return $"{Book}{BookChapterDelimiter}{Chapter}{ChapterVersesDelimiter}{StartVerse}{VerseDelimiter}{EndVerse}";
            }
        }
        set
        {
            Parse(value);
        }
    }
    public string ToChapterString(Boolean showVerses = true)
    {
        if (showVerses)
        {
            return ToString;
        }
        else
        {
            return $"{Book}{BookChapterDelimiter}{Chapter}";
        }
    }
    public Reference(string book, int chapter, int verse)
    {
        BookChapterDelimiter = " ";
        ChapterVersesDelimiter = ":";
        VerseDelimiter = "-";
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        BookChapterDelimiter = " ";
        ChapterVersesDelimiter = ":";
        VerseDelimiter = "-";
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
    public Reference(string referenceString, Boolean isObjectString = false)
    {
        if(isObjectString)
        {
            ObjectString = referenceString;
        }
        else
        {
            ToString = referenceString;
        }
    }
    public Boolean ValidateVersesToReference(Verses verses)
    {
        return (verses.VerseCount == (EndVerse - StartVerse + 1));
    }
    public Boolean ValidateVerseToReference(Verse verse)
    {
        return (1 == (EndVerse - StartVerse + 1));
    }
    public void ParseLabeledChapterString(string labeledChapterString, string chapterDelimter)
    {
        string[] parts = labeledChapterString.Split(chapterDelimter);
        List<string> partsList = new List<string>(parts);
        ParseChapterString(partsList[0]);
        partsList.RemoveAt(0);
        string verses = String.Join(chapterDelimter, partsList);
        Verses verseHandle = new Verses(new List<Verse>());
        List<string> verseList = verseHandle.GetVerseStringList(verses);
        StartVerse = -1;
        EndVerse = -1;
        foreach (string element in verseList)
        {
            string[] elementParts = element.Split("  ");
            int verseNum = int.Parse(elementParts[0]);
            if(StartVerse == -1||verseNum< StartVerse)
            {
                StartVerse = verseNum;
            }
            if(verseNum > EndVerse)
            {
                EndVerse = verseNum;
            }
        }
    }
    public void ParseChapterString(string reference)
    {
        if (reference.Contains(BookChapterDelimiter) && reference.Contains(ChapterVersesDelimiter))
        {
            string[] parts = reference.Split(BookChapterDelimiter);
            List<string> partsList = new List<string>(parts);
            Book = partsList[0];
            partsList.Remove(partsList[0]);
            string remainder = String.Join(BookChapterDelimiter, partsList);
            parts = reference.Split(ChapterVersesDelimiter);
            partsList = new List<string>(parts);
            Chapter = int.Parse(partsList[0]);
        }
        else if (reference.Contains(BookChapterDelimiter))
        {
            string[] parts = reference.Split(BookChapterDelimiter);
            List<string> partsList = new List<string>(parts);
            Book = partsList[0];
            Chapter = int.Parse(partsList[1]);
        }
    }
    public void Parse(string reference)
    {
        ParseChapterString(reference);
        if (reference.Contains(BookChapterDelimiter)&&reference.Contains(ChapterVersesDelimiter)&&reference.Contains(VerseDelimiter)) {
            string[] parts = reference.Split(BookChapterDelimiter);
            List<string> partsList = new List<string>(parts);
            partsList.Remove(partsList[0]);
            string remainder = String.Join(BookChapterDelimiter, partsList);
            parts = reference.Split(ChapterVersesDelimiter);
            partsList = new List<string>(parts);
            partsList.Remove(partsList[0]);
            remainder = String.Join(ChapterVersesDelimiter, partsList);
            parts = reference.Split(VerseDelimiter);
            partsList = new List<string>(parts);
            StartVerse = int.Parse(partsList[0]);
            EndVerse = int.Parse(partsList[1]);
        }
        else if(reference.Contains(BookChapterDelimiter)&& reference.Contains(ChapterVersesDelimiter))
        {
            string[] parts = reference.Split(BookChapterDelimiter);
            List<string> partsList = new List<string>(parts);
            partsList.Remove(partsList[0]);
            string remainder = String.Join(BookChapterDelimiter, partsList);
            parts = reference.Split(ChapterVersesDelimiter);
            partsList = new List<string>(parts);
            StartVerse = int.Parse(partsList[1]);
            EndVerse = int.Parse(partsList[1]);
        }
    }
    public string LabelVerse(int verseIndex, string verseText)
    {
        return $"{(StartVerse + verseIndex).ToString()}  {verseText}";
    }
    public string RemoveVerseLabel(int verseIndex, string verseText)
    {
        string[] parts = verseText.Split((StartVerse + verseIndex).ToString()+"  ");
        List<string> partsList = new List<string>(parts);
        partsList.Remove(partsList[0]);
        return String.Join((StartVerse + verseIndex).ToString(), partsList);
    }
}
