using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiddleManager : MonoBehaviour
{
    #region "Fields"

    public static List<Riddle> _riddles = new List<Riddle>();
    public static Riddle _currentRiddle;
    public static int _riddleNumber = 0;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AnswerButton[] _answerButtons;

    #endregion

    void Awake() => _riddles = JsonMaster.ParseResource<Riddle>("Riddles");

    private void Start()
    {
        QuestProgressChanger.OnProgressCounterChanged.AddListener(SolveRiddle);
    }

    public void SetRiddleInformation(int index)
    {
        _riddleNumber = index;
        _currentRiddle = _riddles[_riddleNumber];      
        _text.text = _currentRiddle._text;

        if (QuestProgressChanger._progressCounter > _riddleNumber)
            _riddles[_riddleNumber]._isSolved = true;

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].SetColor(Color.white);
            _answerButtons[i].SetText(_currentRiddle._answers[i]);
        }

        if (IsSelectedRiddleSolved())
            _answerButtons[_riddles[index]._correctAnswer - 1].SetColor(new Color(0.386596f, 0.8584906f, 0.3199092f, 1f));
    }

    public static void SolveRiddle()
    {
        _riddles[_riddleNumber]._isSolved = true;
        Debug.Log("Riddle solved: " + _riddleNumber);
    }

    public static string GetCurrentRiddleAnswer()
    {
        return _currentRiddle._answers[_currentRiddle._correctAnswer - 1];
    }

    public static bool IsSelectedRiddleSolved()
    {
        return _riddles[_riddleNumber]._isSolved;
    }
}
