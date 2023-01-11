using UnityEngine;

public class ObjectsActiveStateSwitch : MonoBehaviour
{
    public GameObject[] objectsToHideShow;
    private bool _isOpen;

    void Start() => _isOpen = objectsToHideShow[0].activeInHierarchy;

    public void SwitchActiveState()
    {
        _isOpen = !_isOpen;
        foreach (GameObject obj in objectsToHideShow)
            obj.SetActive(_isOpen);
    }
}
