class Word
{
    private string PreFixPunctuation { get; set; }
    private string WordString { get; set; }
    private string PostFixPunctuation { get; set; }
    public Boolean IsHidden { get; private set; }
    private char CharUsedToHide { get; set; }
    public string ObjectString
    {
        get
        {
            return $"IsHidden - <{IsHidden.ToString()}>" +
                $" , PreFixPunctuation - <{PreFixPunctuation}>" +
                $" , WordString - <{WordString}>" +
                $" , PostFixPunctuation - <{PostFixPunctuation}>" +
                $" , CharUsedToHide - <{CharUsedToHide}>";
        }
        set
        {
            string[] fieldStringArray = value.Split(" , ");
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
                    case "IsHidden":
                        IsHidden = Boolean.Parse(field.Item2);
                        break;
                    case "PreFixPunctuation":
                        PreFixPunctuation = field.Item2;
                        break;
                    case "WordString":
                        WordString = field.Item2;
                        break;
                    case "PostFixPunctuation":
                        PostFixPunctuation = field.Item2;
                        break;
                    case "CharUsedToHide":
                        CharUsedToHide = char.Parse(field.Item2);
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
            if (IsHidden)
            {                
                return $"{PreFixPunctuation}{new String(CharUsedToHide, WordString.Length)}{PostFixPunctuation}";
            }
            else
            {
                return $"{PreFixPunctuation}{WordString}{PostFixPunctuation}";
            }
        }
        set
        {
            Parse(value);
        }
    }
    public Word(string word)
    {
        PreFixPunctuation = "";
        PostFixPunctuation = "";
        IsHidden = false;
        CharUsedToHide = '_';
        WordString = word;
    }
    public Word(string string1, string string2, bool definePre = true)
    {
        IsHidden = false;
        CharUsedToHide = '_';
        if (definePre)
        {
            PreFixPunctuation = string1;
            WordString = string2;
            PostFixPunctuation = "";
        }
        else
        {
            PreFixPunctuation = "";
            WordString = string1;
            PostFixPunctuation = string2;
        }
    }
    public Word(string preFixPunctuation, string word, string postFixPunctuation)
    {
        IsHidden = false;
        CharUsedToHide = '_';
        PreFixPunctuation = preFixPunctuation;
        WordString = word;
        PostFixPunctuation = postFixPunctuation;
    }
    public Word(string word, char charUsedToHide)
    {
        PreFixPunctuation = "";
        PostFixPunctuation = "";
        IsHidden = false;
        WordString = word;
        CharUsedToHide = charUsedToHide;
    }
    public Word(string string1, string string2, char charUsedToHide, bool definePre = true)
    {
        IsHidden = false;
        if (definePre)
        {
            PreFixPunctuation = string1;
            WordString = string2;
            PostFixPunctuation = "";
        }
        else
        {
            PreFixPunctuation = "";
            WordString = string1;
            PostFixPunctuation = string2;
        }
        CharUsedToHide = charUsedToHide;
    }
    public Word(string preFixPunctuation, string word, string postFixPunctuation, char charUsedToHide)
    {
        IsHidden = false;
        PreFixPunctuation = preFixPunctuation;
        WordString = word;
        PostFixPunctuation = postFixPunctuation;
        CharUsedToHide = charUsedToHide;
    }
    public Word(string wordString, Boolean isObjectString = false)
    {
        if (isObjectString)
        {
            ObjectString = wordString;
        }
        else
        {
            ToString = wordString;
        }
    }
    public void Show()
    {
        IsHidden = false;
    }
    public void Hide()
    {
        IsHidden = true;
    }
    private Boolean IsAlphaNumChar(char character)
    {
        return Char.IsLetterOrDigit(character) && character != '.' && character != ',';
    }
    public void Parse(string input)
    {
        int position = 0;
        int firstAlphaNum = 0;
        Boolean firstAlphaNumFound = false;
        int lastAlphaNum = 0;
        Boolean lastAlphaNumFound = false;
        foreach (char c in input)
        {
            if (IsAlphaNumChar(c) && !firstAlphaNumFound)
            {
                firstAlphaNumFound = true;
                firstAlphaNum = position;
            }
            position++;
        }
        if (firstAlphaNumFound)
        {
            for(int i=input.Length; i>0; i--)
            {
                if (IsAlphaNumChar(input[i-1]) && !lastAlphaNumFound)
                {
                    lastAlphaNumFound = true;
                    lastAlphaNum = i;
                }
            }
        }
        if (firstAlphaNumFound || lastAlphaNumFound)
        {
            if((firstAlphaNum==0)&&(lastAlphaNum==(input.Length)))
            {
                PreFixPunctuation = "";
                WordString = input;
                PostFixPunctuation = "";
            }
            else if(firstAlphaNum == 0)
            {
                PreFixPunctuation = "";
                WordString = input.Substring(0, lastAlphaNum);
                PostFixPunctuation = input.Substring(lastAlphaNum);
            }
            else if (lastAlphaNum == (input.Length))
            {
                PreFixPunctuation = input.Substring(0, firstAlphaNum);
                WordString = input.Substring(firstAlphaNum);
                PostFixPunctuation = "";
            }
            else
            {
                PreFixPunctuation = input.Substring(0, firstAlphaNum);
                WordString = input.Substring(firstAlphaNum, lastAlphaNum - firstAlphaNum);
                PostFixPunctuation = input.Substring(lastAlphaNum);
            }
        }
        else
        {
            PreFixPunctuation = input;
        }
    }
    public Boolean IsElligible()
    {
        return (WordString.Length > 0);
    }
}
