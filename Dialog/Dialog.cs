[System.Serializable]
public class Dialog
{
    public string _title;
    public string[] _messages;

    public Dialog() { }

    public Dialog(string title, string[] messages) 
    {
        _title = title;
        _messages = messages;
    }
}