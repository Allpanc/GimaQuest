using System;
using UnityEngine;
using UnityEngine.Events;

public class WelcomeTutorial : Tutorial
{
    #region "Fields"

    [SerializeField] private Hud _hud;
    [SerializeField] private MenuTutorial _menuTutorial;
    [SerializeField] private ImageTargetsController _imageTargetsController;
    [SerializeField] private DialogSystem _dialogSystem;

    public static UnityEvent OnStartTargetFoundCompleted = new UnityEvent();
    #endregion

    #region "Overrides"

    protected override void Awake()
    {
        base.Awake();
        _hud.gameObject.SetActive(true);
    }

    protected override void Start()
    {
        base.Start();
        DialogSystem.OnDialogSkipped.AddListener(CompleteStep);
        DialogSystem.OnFirstDialogSkipped.AddListener(ActivateHood);
        MenuTutorial.OnMenuTutorialCompleted.AddListener(TurnOnAnimalImageTargets);
        GameProgressManager.OnQuestProgressLoaded.AddListener(SkipTutorials);
    }

    protected override void ExecuteStep()
    {
        base.ExecuteStep();
        if (_steps[_currentStepIndex].gameObject)
            _steps[_currentStepIndex].gameObject.SetActive(false);
        try
        {
            _steps[_currentStepIndex + 1].gameObject.SetActive(true);
        }
        catch (ArgumentOutOfRangeException) { }
    }
    #endregion

    // Step 0
    public void OnStartButtonPressed()
    {
        CompleteStep();
        _imageTargetsController.SetStartTargetEnabledState(true);
    }

    // Step 1
    public void OnStartTargetFound()
    {
        CompleteStep();
        OnStartTargetFoundCompleted.Invoke();
        if (!_menuTutorial._isCompleted)
            _imageTargetsController.SetStartTargetEnabledState(false);
    }

    private void ActivateHood() => _hud.gameObject.SetActive(true);

    // Вызывается после завершения menu tutorial
    private void TurnOnAnimalImageTargets()
    {
        _imageTargetsController.SetAnimalTargetEnabledState(0, true);
        CompleteStep();
    }

    // Вызывается, при загрузке сохраненного игрового прогресса
    private void SkipTutorials()
    {
        OnStartTargetFound();
        _dialogSystem.SkipDialog();
        _menuTutorial.Skip();
        _hud.gameObject.SetActive(true);
    }
}
