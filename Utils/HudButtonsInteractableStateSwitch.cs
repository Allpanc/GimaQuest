using UnityEngine;
using UnityEngine.UI;

public class HudButtonsInteractableStateSwitch : MonoBehaviour
{
    public Button[] hudButtons;

    public void SetHudButtonState(int index, bool state) => hudButtons[index].interactable = state;

    public void SetHudButtonsState(bool state)
    {
        foreach (Button button in hudButtons)
            button.interactable = state;
    }
}
