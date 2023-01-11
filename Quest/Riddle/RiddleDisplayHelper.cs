using UnityEngine;

public class RiddleDisplayHelper : MonoBehaviour
{
    [SerializeField] private GameObject _riddlePanel;

    public void ShowRiddle()
    {
        _riddlePanel.SetActive(true);
        _riddlePanel.GetComponent<RiddleManager>().SetRiddleInformation(transform.GetSiblingIndex());
    }

    public void HideRiddle()
    {
        _riddlePanel.SetActive(false);
    }
}
