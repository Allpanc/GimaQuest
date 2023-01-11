using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SpriteSwapper : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private bool isFirstSelected = true;

    public void SwapSprites()
    {
        if (isFirstSelected)
            GetComponent<Image>().sprite = sprite1;
        else
            GetComponent<Image>().sprite = sprite2;
        isFirstSelected = !isFirstSelected;
    }
}
