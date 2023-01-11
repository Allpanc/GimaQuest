using System.Collections;
using UnityEngine;

public class ArStartDeactivator : MonoBehaviour
{
    [Header("AR Controllers")]
    [SerializeField] private ImageTargetsController _imageTargetsController;
    [SerializeField] private GroundPlaneController _groundPlaneController;

    void Start()
    {
        StartCoroutine(TurnOffImageTracking());
        StartCoroutine(TurnOffPlaneFinder());
    }

    IEnumerator TurnOffImageTracking()
    {
        yield return null;
        _imageTargetsController.SetAllTargetsEnabledState(false);
    }

    IEnumerator TurnOffPlaneFinder()
    {
        yield return null;
        _groundPlaneController.SetAllGroundPlaneItemsEnabledState(false);
    }
}
