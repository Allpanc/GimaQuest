using UnityEngine;

[ExecuteInEditMode]
public class AnimalScaleAdjuster : MonoBehaviour
{
    [SerializeField] private GameObject[] _imageTargetAnimals;
    [SerializeField] private GameObject[] _groundPlaneAnimals;
    [Range(0.1f,10)]
    [SerializeField] private float _planeScale;
    [Range(1f, 10)]
    [SerializeField] private float _imageScale;

    private void Start() => AdjuctScale();
    
    private void Update() => AdjuctScale();

    public void AdjuctScale()
    {
        foreach (GameObject imageTargetAnimal in _imageTargetAnimals)
            imageTargetAnimal.transform.localScale = Vector3.one * _imageScale;

        foreach (GameObject groundPlaneAnimal in _groundPlaneAnimals)
            groundPlaneAnimal.transform.localScale = Vector3.one * _planeScale;
    }
}
