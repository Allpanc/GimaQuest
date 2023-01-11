using UnityEngine;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private DialogView _dialogView;
    private Dialog _currentDialog;
    private int _messageNumber = 0;
    private bool _userWasAlreadyWelcomed;

    private enum DialogOptions
    {
        Welcome,
        Congratulations,
        Was_Already_Welcomed
    }

    public static UnityEvent OnDialogSkipped = new UnityEvent();
    public static UnityEvent OnFirstDialogSkipped = new UnityEvent();
    public static int _currentDialogIndex { get; private set; } = 0;

    void Start()
    {
        WelcomeTutorial.OnStartTargetFoundCompleted.AddListener(ShowWelcomeDialog);
    }

    public void GoForward()
    {
        if (_messageNumber < _currentDialog._messages.Length - 1)
            _dialogView.ShowMessage(_currentDialog._messages[++_messageNumber]);
        else
            SkipDialog();
    }

    public void GoBack()
    {
        if (_messageNumber > 0)
            _dialogView.ShowMessage(_currentDialog._messages[--_messageNumber]);
    }

    public void SkipDialog()
    {
        if (_currentDialog._title == DialogOptions.Welcome.ToString())
            OnFirstDialogSkipped.Invoke();

        OnDialogSkipped.Invoke();
        _dialogView.HideDialogPanel();
    }

    private void SetDialogInformation(string title)
    {
        _currentDialog = DialogRepository.GetDialogByTitle(title);
        _dialogView.ResetDialogInformation(_currentDialog);
        _messageNumber = 0;
    }

    private void ShowWelcomeDialog()
    {
        if (!_userWasAlreadyWelcomed)
        {
            SetDialogInformation(DialogOptions.Welcome.ToString());
            _userWasAlreadyWelcomed = true;
        }
        else
        {
            SetDialogInformation(DialogOptions.Was_Already_Welcomed.ToString());
        }
    }

    public void ShowCongratulationsDialog()
    {
        SetDialogInformation(DialogOptions.Congratulations.ToString());
    }
}
