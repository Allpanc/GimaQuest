using UnityEngine;

public class AugmentedRealityModeSwitcher : MonoBehaviour
{
    #region "Fields"
    [SerializeField] private GameObject _arModeButton;
    [SerializeField] private GameObject _arOverlay;

    [SerializeField] private ImageTargetsController _imageTargetsController;
    [SerializeField] private GroundPlaneController _groundPlaneController;

    public enum ARMode
    {
        Image,
        Plane
    }

    public static ARMode _currentARMode = ARMode.Image;
    #endregion

    private void Start() 
    {
        DialogSystem.OnDialogSkipped.AddListener(ShowARModeButton);
        GameProgressManager.OnCreativeModeLoaded.AddListener(ShowARModeButton);
        GameProgressManager.OnGameProgressCleared.AddListener(HideARModeButton);
    } 

    private void ShowARModeButton()
    {
        if (QuestProgressChanger._isMainlyCompleted)
        {
            _arModeButton.SetActive(true);
            QuestProgressChanger.ChangeProgressCounter();
        }
    }

    private void HideARModeButton() => _arModeButton.SetActive(false);

    public void SwitchARModes()
    {
        bool state = _groundPlaneController.IsPlaneFinderEnabled();

        if (state)
            _currentARMode = ARMode.Image;
        else
            _currentARMode = ARMode.Plane;

        _imageTargetsController.SetAllTargetsEnabledState(state);
        _groundPlaneController.SetAllGroundPlaneItemsEnabledState(!state);
        _arOverlay.SetActive(!state);

        Debug.LogWarning("AR mode switched, plane finder enabled: " + !state);
        Debug.LogWarning("Current AR mode: " + _currentARMode);
    }
}
