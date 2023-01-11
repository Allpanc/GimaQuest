[System.Serializable]
public class Riddle
{
    public string _text;
    public string[] _answers = new string[3];
    public int _correctAnswer;
    public bool _isSolved;

    public Riddle(){}

    public Riddle(string text, string answer1, string answer2, string answer3, int correctAnswer, bool isSolved = false)
    {
        _text = text;
        _answers[0] = answer1;
        _answers[1] = answer2;
        _answers[2] = answer3;
        _correctAnswer = correctAnswer;
    }
}
