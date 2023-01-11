using System.Collections;
using UnityEngine;

public class Hud : MonoBehaviour
{
    #region "Fields"

    [Header("Subsystems")]
    [SerializeField] private GameObject _puzzle;
    [SerializeField] private GameObject _notes;
    [SerializeField] private GameObject _map;

    [Header("AR")]
    [SerializeField] private Camera _arCamera;
    [SerializeField] private AugmentedRealityModeSwitcher _arSwitcher;

    #endregion

    private void Awake()
    {
        _puzzle.SetActive(true);
        _notes.SetActive(true);
        _map.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(DisableSubsystems());
    }

    public void OnPuzzleButtonClick()
    {
        _puzzle.SetActive(true);
        _arCamera.enabled = false;
    }    
    
    public void OnNotesButtonClick()
    {
        _notes.SetActive(true);
        _arCamera.enabled = false;
    }    
    
    public void OnMapButtonClick()
    {
        _map.SetActive(true);
        _arCamera.enabled = false;
    }    
    
    public void OnArModeButtonClick()
    {
        _arSwitcher.SwitchARModes();
    }

    public void OnCloseButtonClick()
    {
        _arCamera.enabled = true;
        if (_puzzle.activeInHierarchy)
            _puzzle.SetActive(false);
        else if (_notes.activeInHierarchy)
            _notes.SetActive(false);
        else if (_map.activeInHierarchy)
            _map.SetActive(false);
    }

    IEnumerator DisableSubsystems()
    {
        yield return null;
        _puzzle.SetActive(false);
        _notes.SetActive(false);
        _map.SetActive(false);
        gameObject.SetActive(false);
    }
}
