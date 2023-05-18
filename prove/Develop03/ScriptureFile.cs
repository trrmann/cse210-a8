class ScriptureFile
{
    private string _filename;
    private string Filename {
        get {
            if(_filename is null)
            {
                return "scriptures.json";
            }
            else
            {
                return _filename;
            }
        }
        set {
            _filename = value;
        }
    }
    public Boolean DoesFileExist {
        get
        {
            return File.Exists(Filename);
        }
    }
    public ScriptureFile()
    {   
    }
    public ScriptureFile(string filename)
    {
        Filename = filename;
    }
    public void WriteFile(string contents)
    {
        File.WriteAllText(Filename, contents);
    }
    public string ReadFile()
    {
        return File.ReadAllText(Filename);
    }
    public void DeleteFile()
    {
        File.Delete(Filename);
    }
}