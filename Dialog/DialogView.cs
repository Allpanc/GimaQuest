using TMPro;
using UnityEngine;

public class DialogView : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private GameObject _dialogPanel;

    //public void ResetDialogInformation(int dialogIndex)
    //{
    //    if (dialogIndex != 0 && dialogIndex < DialogRepository.GetDialogs().Length)
    //        _dialogPanel.SetActive(true);

    //    Dialog currentDialog = DialogRepository.GetDialogs()[dialogIndex];

    //    float optimalFontSize = FontSizeAdjustHelper.GetAdjustedFontSize(_dialogText, currentDialog._messages);
    //    _dialogText.enableAutoSizing = false;
    //    _dialogText.fontSize = optimalFontSize;
    //    _dialogText.text = currentDialog._messages[0];
    //}

    public void ResetDialogInformation(Dialog dialog)
    {
        _dialogPanel.SetActive(true);

        float optimalFontSize = FontSizeAdjustHelper.GetAdjustedFontSize(_dialogText, dialog._messages);
        _dialogText.enableAutoSizing = false;
        _dialogText.fontSize = optimalFontSize;
        _dialogText.text = dialog._messages[0];
    }

    public void ShowMessage(string message)
    {
        _dialogText.text = message;
    }

    public void HideDialogPanel()
    {
        _dialogPanel.SetActive(false);
    }
}
