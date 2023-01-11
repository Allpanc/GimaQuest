using UnityEngine;
using UnityEngine.Events;

public class MenuTutorial : Tutorial
{
    
    #region "Fields"

    [Header("Hud buttons controller")]
    [SerializeField] private HudButtonsInteractableStateSwitch _hudSwitch;

    protected override void Awake() => base.Awake();
    public static UnityEvent OnMenuTutorialCompleted = new UnityEvent();

    #endregion

    public void OnSwitchStepsButtonClick()
    {
        CompleteStep();
    }

    public void Skip()
    {
        for (int i = 0; i < _stepsCount; i++)
            OnSwitchStepsButtonClick();
    }

    protected override void ExecuteStep()
    {
        base.ExecuteStep();
        _steps[_currentStepIndex].gameObject.SetActive(false);
        if (_currentStepIndex < _steps.Count - 1)
        {
            _steps[_currentStepIndex + 1].gameObject.SetActive(true);
            _hudSwitch.SetHudButtonState(_currentStepIndex + 1, true);
        }
        else
        {
            _isCompleted = true;
            OnMenuTutorialCompleted.Invoke();
        }
    }
}
