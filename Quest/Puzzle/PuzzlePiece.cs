using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Image))] 

public class PuzzlePiece : MonoBehaviour
{
    private Image image;
    public Sprite openedPiece;
    public Sprite closedPiece;
    public bool isOpened;

    void Start() => image = GetComponent<Image>();

    public void Open()
    {
        image.sprite = openedPiece;
        isOpened = true;
        //Debug.LogWarning("Open");
    }

    public void Close()
    {
        image.sprite = closedPiece;
        isOpened = false;
    }
}
