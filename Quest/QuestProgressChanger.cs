using UnityEngine;
using UnityEngine.Events;

public class QuestProgressChanger : MonoBehaviour
{
    #region "Fields"

    public static int _progressCounter { get; private set; } = 0;
    public static bool _isMainlyCompleted { get; private set; }
    public static bool _isFullyCompleted { get; private set; }

    public static UnityEvent OnProgressCounterChanged =  new UnityEvent();
    public static UnityEvent OnQuestMainPartCompleted = new UnityEvent();
    public static UnityEvent OnQuestFullyCompleted = new UnityEvent();
    #endregion

    public static void ChangeProgressCounter()
    {
        if (!_isMainlyCompleted)
        {
            _progressCounter++;

            OnProgressCounterChanged.Invoke();
            Debug.LogWarning("Quest Progress " + _progressCounter);

            if (_progressCounter == 6)
            {
                _isMainlyCompleted = true;
                OnQuestMainPartCompleted.Invoke();
                Debug.LogWarning("Quest main part is completed ");
            }
        }
        else
        {
            _isFullyCompleted = true;
            OnQuestFullyCompleted.Invoke();

            Debug.LogWarning("Quest is fully completed ");
        }
    }

    public static void ResetProgressCounter() 
    {
        _progressCounter = 0;
        _isMainlyCompleted = false;
        _isFullyCompleted = false;
        Debug.LogWarning("Reset progress counter " + _progressCounter);
    }
}
