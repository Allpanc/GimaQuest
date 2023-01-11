using UnityEngine;

[CreateAssetMenu(fileName = "Game Progress Repository", menuName = "Game Progress Repository")]
public class GameProgressRepository : ScriptableObject
{
    public int _progressCounter;
    public bool _isStartCompleted;
    public bool _isQuestMainPartCompleted;
    public bool _isQuestFullyCompleted;
}
