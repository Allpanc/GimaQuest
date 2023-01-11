using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    [Header("Rotation settings")]
    public float rotationSpeed = 1f;

    private Touch touchZero;

    private void Update()
    {
        transform.localPosition = Vector3.zero;
        if (Input.touchCount == 1 )
        {
            touchZero = Input.GetTouch(0);
            if (touchZero.phase == TouchPhase.Moved && (touchZero.position.y > (float)Screen.height * 0.6))
                GetComponent<Rigidbody>().AddTorque(new Vector3(0, -touchZero.deltaPosition.x * rotationSpeed/50, 0), ForceMode.Acceleration);
        }        
    }
}
