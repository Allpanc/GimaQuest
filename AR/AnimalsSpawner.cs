using UnityEngine;
using Vuforia;

public class AnimalsSpawner : MonoBehaviour
{
    [SerializeField] private PlaneFinderBehaviour _planeFinder;
    [SerializeField] private AnchorBehaviour[] _anchorStages;
    [SerializeField] private PlaneIndicatorTextureChanger _planeIndicatorChanger;
    private int _previousStageIndex = 0;

    public void SetGroundPlaneContent(int index)
    {
        if (index >= 0 && index < _anchorStages.Length)
        {
            _planeFinder.transform.GetComponent<ContentPositioningBehaviour>().AnchorStage = _anchorStages[index];
            _planeIndicatorChanger.ChangePlaneIndicatorTexture(index);
            _previousStageIndex = index;
            Debug.LogWarning("Contect set, index = " + index);
        }
    }

    public void ClearGroundPlaneContent()
    {
        AnchorBehaviour[] anchorStages = FindObjectsOfType<AnchorBehaviour>();
        foreach (AnchorBehaviour anchorStage in anchorStages)
        {
            if (anchorStage.transform.parent == null)
                Destroy(anchorStage.gameObject);
        }
        SetGroundPlaneContent(_previousStageIndex);
    }
}