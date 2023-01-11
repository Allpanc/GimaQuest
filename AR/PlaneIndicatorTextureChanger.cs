using UnityEngine;

public class PlaneIndicatorTextureChanger : MonoBehaviour
{

    [SerializeField] private Texture2D[] _albedos;
    [SerializeField] private MeshRenderer _planeIndicatorMeshRenderer;

    private void Start() 
    {
        ChangePlaneIndicatorTexture(0);
    }

    public void ChangePlaneIndicatorTexture(int index)
    {
        _planeIndicatorMeshRenderer.sharedMaterial.SetTexture("AlbedoTexture", _albedos[index]);
    }
}
