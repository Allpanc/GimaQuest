using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialImageTrackingDeactivator : MonoBehaviour
{
    [SerializeField] private ImageTargetsController _imageTargetsController;

    void Start()
    {
        StartCoroutine(TurnOffImageTracking());
    }

    IEnumerator TurnOffImageTracking()
    {
        yield return null;
        _imageTargetsController.SetAllTargetsEnabledState(false);
    }
}
