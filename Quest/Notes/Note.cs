[System.Serializable]

public class Note
{
    public string _title;
    public string _mainParameters;
    public string _description;
    public string[] _interestingFacts;

    public Note(int index, string title, string mainParameters, string description, string[] interestingFacts)
    {
        _title = title;
        _mainParameters = mainParameters;
        _description = description;
        _interestingFacts = interestingFacts;
    }
}
