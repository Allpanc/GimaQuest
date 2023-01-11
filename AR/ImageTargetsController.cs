using UnityEngine;
using Vuforia;

public class ImageTargetsController : MonoBehaviour
{
    [SerializeField] private ImageTargetBehaviour _startTarget;
    [SerializeField] private ImageTargetBehaviour _finishTarget;
    [SerializeField] private ImageTargetBehaviour[] _animalTargets;

    void Start()
    {
        QuestProgressChanger.OnProgressCounterChanged.AddListener(SetAnimalTargetEnabledState);
        MenuTutorial.OnMenuTutorialCompleted.AddListener(TurnOnStartTarget);
    }

    public void SetStartTargetEnabledState(bool state)
    {
        _startTarget.enabled = state;
    }

    public void TurnOnStartTarget()
    {
        _startTarget.enabled = true;
    }

    public void SetFinishTargetEnabledState(bool state)
    {
        _finishTarget.enabled = state;
    }

    public void SetAnimalTargetEnabledState()
    {
        if (QuestProgressChanger._progressCounter<_animalTargets.Length)
            _animalTargets[QuestProgressChanger._progressCounter].enabled = true;
    }

    public void SetAnimalTargetEnabledState(int index, bool state)
    {
        if (index < _animalTargets.Length && index >= 0)
            _animalTargets[index].enabled = state;
    }

    public void SetAnimalTargetsEnabledState(bool state)
    {
        foreach (ImageTargetBehaviour targetBehaviour in _animalTargets)
            targetBehaviour.enabled = state;
    }

    public void SetAllTargetsEnabledState(bool state)
    {
        SetStartTargetEnabledState(state);
        SetAnimalTargetsEnabledState(state);
        SetFinishTargetEnabledState(state);
    }
}
