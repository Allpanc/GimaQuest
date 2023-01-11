using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzlePiece[] _pieces;

    private void Start() => QuestProgressChanger.OnProgressCounterChanged.AddListener(ChangePuzzle);

    private void ChangePuzzle()
    {
        if (QuestProgressChanger._progressCounter <= _pieces.Length)
            _pieces[QuestProgressChanger._progressCounter-1].Open();

        //Debug.LogWarning("Puzzle changed " + (Quest._progressCounter - 1) + " opened");
    }
}
