using UnityEngine;

public class QuestMainPart : MonoBehaviour
{
    [SerializeField] private ImageTargetsController _imageTargetsController;

    void Start()
    {
        QuestProgressChanger.OnQuestMainPartCompleted.AddListener(TurnOnLastImageTarget);
        GameProgressManager.OnMainPartFullyCompletedLoaded.AddListener(FullyCompleteQuest);
    }

    // Вызывается после завершения основной части квеста (все, кроме финишных ворот)
    public void TurnOnLastImageTarget()
    {
        Debug.LogWarning("Last target on");
        _imageTargetsController.SetFinishTargetEnabledState(true);
    }

    public void FullyCompleteQuest()
    {
        if (QuestProgressChanger._isMainlyCompleted)
            QuestProgressChanger.ChangeProgressCounter();
    }
}
