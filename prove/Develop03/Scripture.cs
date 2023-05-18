class Scripture
{
    private Reference Reference { get; set;}
    private int TimesUsed { get; set; }
    private DateTime LastUsed { get; set; }
    private Verses Verses { get; set; }
    public Boolean AreAllHidden {
        get
        {
            return Verses.AreAllHidden;
        }
    }
    public string ObjectString
    {
        get
        {
            return $"Reference - <{Reference.ObjectString}>" +
                $" -f- TimesUsed - <{TimesUsed}>" +
                $" -f- LastUsed - <{LastUsed}>" +
                $" -f- Verses - <{Verses.ObjectString}>";
        }
        set
        {
            string[] fieldStringArray = value.Split(" -f- ");
            List<string> fieldStringList = new List<string>(fieldStringArray);
            List<Tuple<string, string>> fields = new List<Tuple<string, string>>();
            foreach (string fieldString in fieldStringList)
            {
                List<string> partsList = new List<string>(fieldString.Split(" - "));
                Tuple<string, string> field = new Tuple<string, string>(partsList[0], "");
                partsList.RemoveAt(0);
                field = new Tuple<string, string>(field.Item1, String.Join(" - ", partsList));
                List<string> valuesList = new List<string>(field.Item2.Split("<"));
                valuesList.RemoveAt(0);
                field = new Tuple<string, string>(field.Item1, String.Join("<", valuesList));
                valuesList = new List<string>(field.Item2.Split(">"));
                valuesList.RemoveAt(valuesList.Count - 1);
                field = new Tuple<string, string>(field.Item1, String.Join(">", valuesList));
                switch (field.Item1)
                {
                    case "Reference":
                        Reference = new Reference(field.Item2,true);
                        break;
                    case "TimesUsed":
                        TimesUsed = int.Parse(field.Item2);
                        break;
                    case "LastUsed":
                        LastUsed = DateTime.Parse(field.Item2);
                        break;
                    case "Verses":
                        Verses = new Verses(field.Item2, true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public new string ToString {
        get
        {
            return $"{Reference.ToChapterString(false)}:  {Verses.ToLabeledString(Reference)}";
        }
        set
        {
            Reference = new Reference("",0,0);
            Reference.ParseLabeledChapterString(value, ":  ");
            Verses = new Verses(new List<Verse>());
            string[] parts = value.Split(":  ");
            List<string> partsList = new List<string>(parts);
            partsList.RemoveAt(0);
            string remainder = String.Join(":  ", partsList);
            Verses.ParseLabeledString(Reference, remainder);
        }
    }
    public Scripture(Reference reference, Verses verses)
    {
        if(reference.ValidateVersesToReference(verses))
        {
            Reference = reference;
            Verses = verses;
            LastUsed = DateTime.Now;
            TimesUsed = 0;
        }
    }
    public Scripture(Reference reference, Verse verse)
    {
        if (reference.ValidateVerseToReference(verse))
        {
            Reference = reference;
            List<Verse> verses = new List<Verse>();
            verses.Add(verse);
            Verses = new Verses(verses);
            LastUsed = DateTime.Now;
            TimesUsed = 0;
        }
    }
    public Scripture(string scripture, Boolean objectString=false)
    {
        if(objectString)
        {
            ObjectString = scripture;
        }
        else
        {
            ToString = scripture;
        }
    }
    static public Scripture SelectScripture(Scriptures scriptures)
    {
        return scriptures.SelectScripture();
    }
    public void ResetUsageData()
    {
        LastUsed = DateTime.Now;
        TimesUsed = 0;
    }
    public void HideWords()
    {
        Verses.HideWords();
    }
    public void ResetHidden()
    {
        Verses.ResetHidden();
    }
    static public void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture.ToString);
    }
    public Tuple<Boolean, Tuple<int,int>> ScriptureSelectionApproved(List<Scripture> scriptures, Tuple<int, int> minMax, Boolean accepted=false)
    {
        Boolean approvalState = false;
        int min = minMax.Item1;
        int max = minMax.Item2;
        if (accepted)
        {
            LastUsed = DateTime.Now;
            TimesUsed++;
            approvalState = true;
        }
        if (min == -1 || TimesUsed < min )
        {
            min = TimesUsed;
        }
        if (TimesUsed > max )
        {
            max = TimesUsed;
        }
        if (TimesUsed == min)
        {
            approvalState = true;
        }
        return new Tuple<Boolean, Tuple<int, int>>(approvalState, new Tuple<int, int>(min, max));
    }
}
