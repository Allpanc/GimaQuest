using UnityEngine;
public class LookAtCamera : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        //Debug.LogWarning(_camera.gameObject.name);
    }

    void Update()
    {
        TurnToCamera();
    }

    private void TurnToCamera() => transform.LookAt(_camera.transform.position);
}
