using System.Text.Json;
using System.Text.Json.Serialization;
class Scriptures
{
    static private string FILENAME { get; set; }
    private List<Scripture> ScriptureList { get; set; }
    [JsonInclude]
    public string ObjectString
    {
        get
        {
            List<string> scriptures = new List<string>();
            foreach (Scripture scripture in ScriptureList)
            {
                scriptures.Add(scripture.ObjectString);
            }
            string result = String.Join("\n\n", scriptures);
            return result;
        }
        set
        {
            string[] scriptures = value.Split("\n\n");
            ScriptureList = new List<Scripture>();
            foreach (string scripture in scriptures)
            {
                ScriptureList.Add(new Scripture(scripture, true));
            }
        }
    }
    protected new string ToString {
        get {
            List<string> scriptures = new List<string>();
            foreach (Scripture scripture in ScriptureList)
            {
                scriptures.Add(scripture.ToString);
            }
            string result = String.Join("\n\n",scriptures);
            return result;
        }
        set {
            string[] scriptures = value.Split("\n\n");
            ScriptureList = new List<Scripture>();
            foreach (string scripture in scriptures)
            {
                ScriptureList.Add(new Scripture(scripture));
            }
        }
    }
    private string JSON
    {
        get
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
        set
        {
            Scriptures scriptures = JsonSerializer.Deserialize<Scriptures>(value);
            ScriptureList = scriptures.ScriptureList;
        }
    }
    public Scriptures() { }
    public Scriptures(List<Scripture> scriptures)
    {
        ScriptureList = scriptures;
    }
    public Scriptures(string scriptures, Boolean objectString = false) {
        if (objectString)
        {
            ObjectString = scriptures;
        }
        else
        {
            ToString = scriptures;
        }
    }
    static private Scriptures DefineScriptures() {
        List<Scripture> scriptures = new List<Scripture>();
        Reference reference1 = new Reference("John", 3, 16);
        Verse verse1 = new Verse(new List<Word>());
        verse1.Parse("For God so loved the world, that he gave his only begotten Son, that whosoever" +
            " believeth in him should not perish, but have everlasting life.");
        List<Verse> verseList1 = new List<Verse>();
        verseList1.Add(verse1);
        Verses verses1 = new Verses(verseList1);
        Scripture scripture1 = new Scripture(reference1, verses1);
        scriptures.Add(scripture1);
        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        Verse verse2 = new Verse(new List<Word>());
        verse2.Parse("Trust in the Lord with all thine heart; and lean not unto thine own understanding.");
        Verse verse3 = new Verse(new List<Word>());
        verse3.Parse("In all thy ways acknowledge him, and he shall direct thy paths.");
        List<Verse> verseList2 = new List<Verse>();
        verseList2.Add(verse2);
        verseList2.Add(verse3);
        Verses verses2 = new Verses(verseList2);
        Scripture scripture2 = new Scripture(reference2, verses2);
        scriptures.Add(scripture2);
        scriptures.Add(new Scripture("Alma 30:  7  Now there was no law against a man’s belief; for" +
            " it was strictly contrary to the commands of God that there should be a law which should" +
            " bring men on to unequal grounds.\r\n8  For thus saith the scripture: Choose ye this day," +
            " whom ye will serve.\r\n9  Now if a man desired to serve God, it was his privilege; or" +
            " rather, if he believed in God it was his privilege to serve him; but if he did not believe" +
            " in him there was no law to punish him.\r\n10  But if he murdered he was punished unto death;" +
            " and if he robbed he was also punished; and if he stole he was also punished; and if he" +
            " committed adultery he was also punished; yea, for all this wickedness they were" +
            " punished.\r\n11  For there was a law that men should be judged according to their crimes." +
            " Nevertheless, there was no law against a man’s belief; therefore, a man was punished only" +
            " for the crimes which he had done; therefore all men were on equal grounds."));
        scriptures.Add(new Scripture("D&C 24:  11  In me he shall have glory, and not of himself, whether" +
            " in weakness or in strength, whether in abonds or free;\r\n12  And at all times, and in all" +
            " places, he shall open his mouth and declare my gospel as with the voice of a trump, both day" +
            " and night. And I will give unto him strength such as is not known among men.\r\n13  Require" +
            " not miracles, except I shall command you, except casting out devils, healing the sick, and" +
            " against poisonous serpents, and against deadly poisons;\r\n14  And these things ye shall not" +
            " do, except it be required of you by them who desire it, that the scriptures might be" +
            " fulfilled; for ye shall do according to that which is written.\r\n15  And in whatsoever place" +
            " ye shall enter, and they receive you not in my name, ye shall leave a cursing instead of a" +
            " blessing, by casting off the dust of your feet against them as a testimony, and cleansing your" +
            " feet by the wayside.\r\n16  And it shall come to pass that whosoever shall lay their hands upon" +
            " you by violence, ye shall command to be smitten in my name; and, behold, I will smite them" +
            " according to your words, in mine own due time.\r\n17  And whosoever shall go to law with thee" +
            " shall be cursed by the law."));
        scriptures.Add(new Scripture("Moses 4:  1  And I, the Lord God, spake unto Moses, saying: That Satan," +
            " whom thou hast commanded in the name of mine Only Begotten, is the same which was from the" +
            " beginning, and he came before me, saying—Behold, here am I, send me, I will be thy son, and I" +
            " will redeem all mankind, that one soul shall not be lost, and surely I will do it; wherefore" +
            " give me thine honor.\r\n2  But, behold, my Beloved Son, which was my Beloved and Chosen from the" +
            " beginning, said unto me—Father, thy dwill be done, and the glory be thine forever.\r\n3  Wherefore," +
            " because that Satan rebelled against me, and sought to destroy the agency of man, which I, the Lord" +
            " God, had given him, and also, that I should give unto him mine own power; by the power of mine Only" +
            " Begotten, I caused that he should be cast down;\r\n4  And he became Satan, yea, even the devil, the" +
            " father of all lies, to deceive and to blind men, and to lead them captive at his will, even as many" +
            " as would not hearken unto my voice."));
        return new Scriptures(scriptures); 
    }
    public void ResetUsageData() {
        foreach (Scripture scripture in ScriptureList)
        {
            scripture.ResetUsageData();
        }
    }
    public void ResetHidden() {
        foreach (Scripture scripture in ScriptureList)
        {
            scripture.ResetHidden();
        }
    }
    public Scripture SelectScripture() {
        Scripture result;
        Tuple<Boolean, Tuple<int, int>> scriptureApprovalResult;
        Boolean selectionApproved = false;
        Random random = new Random();
        int min = -1;
        int max = 0;
        foreach (Scripture scripture in ScriptureList)
        {
            scriptureApprovalResult = scripture.ScriptureSelectionApproved(ScriptureList, new Tuple<int, int>(min, max));
            if(min==-1|| scriptureApprovalResult.Item2.Item1 < min)
            {
                min = scriptureApprovalResult.Item2.Item1;
            }
            if(scriptureApprovalResult.Item2.Item2 > max) {
                max = scriptureApprovalResult.Item2.Item2;
            }
        }
        int index = 0;
        int counter = 0;
        while (!selectionApproved&&counter<=ScriptureList.Count)
        {
            index = random.Next(0, ScriptureList.Count);
            scriptureApprovalResult = ScriptureList[index].ScriptureSelectionApproved(ScriptureList, new Tuple<int, int>(min, max));
            selectionApproved = scriptureApprovalResult.Item1;
            counter ++;
        }
        ScriptureList[index].ScriptureSelectionApproved(ScriptureList, new Tuple<int, int>(min, max), true);
        result = ScriptureList[index];
        return result; 
    }
    public void SaveScriptures()
    {
        string json = JSON;
        ScriptureFile scriptureFile = new ScriptureFile(FILENAME);
        scriptureFile.WriteFile(JSON);
    }
    public void LoadScriptures() {
        ScriptureFile scriptureFile = new ScriptureFile(FILENAME);
        //scriptureFile.DeleteFile();
        if (!scriptureFile.DoesFileExist)
        {
            Scriptures scriptures = DefineScriptures();
            scriptures.SaveScriptures();
        }
        JSON = scriptureFile.ReadFile();
    }
}
