public class Application
{
    private Boolean IsRunning { get; set; }
    private Scriptures Scriptures { get; set; }
    private Scripture Current { get; set; }
    public Application(){
        Scriptures = new Scriptures();
        Scriptures.LoadScriptures();
        Current = Scripture.SelectScripture(Scriptures);
        IsRunning = true;
    }
    private void ResetHidden(){
        Scriptures.ResetHidden();
    }
    private void ResetUsageData() {
        Scriptures.ResetUsageData();
    }
    public void Run() {
        Console.Clear();
        Scripture.DisplayScripture(Current);
        while (IsRunning)
        {
            IsRunning = EvaluateResponse(Current, ReadResponse());
            Scriptures.SaveScriptures();
        }
        Exit();
    }
    private string ReadResponse() {
        return Console.ReadLine();
    }
    private Boolean EvaluateResponse(Scripture scripture, string response) {
        switch(response.ToLower())
        {
            case "quit":
                return false;
            default:
                if (scripture.AreAllHidden)
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    scripture.HideWords();
                    Scripture.DisplayScripture(scripture);
                    return true;
                }
        }
    }
    private void Exit() {
        ResetHidden();
        Scriptures.SaveScriptures();
    }
}
