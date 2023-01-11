using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{

    #region "Fields"
    public enum AnimalLocation
    {
        ImageTagret,
        GroundPlane,
        InsideNotes
    }

    [SerializeField] private AnimalLocation _animalLocation;

    private Animator _animator;
    #endregion

    private void Awake() => _animator = GetComponent<Animator>();

    private void OnEnable()
    {
        SwitchAnimation(true);
        //Debug.LogWarning(gameObject.name + " enabled");
    }

    public void SwitchAnimation(bool state)
    {
        switch (_animalLocation)
        {
            case AnimalLocation.ImageTagret:
                _animator.SetBool("isImageTarget", state);
                break;
            case AnimalLocation.GroundPlane:
                _animator.SetBool("isGroundPlane", state);
                break;
            case AnimalLocation.InsideNotes:
                _animator.SetBool("isInsideNotes", state);
                break;
        }
    }
}
