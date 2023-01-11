using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FontSizeAdjustHelper : MonoBehaviour
{
    public static float GetAdjustedFontSize(TMP_Text[] texts)
    {
        float minFontSize = texts[0].fontSize;

        for (int i = 1; i < texts.Length; i++)
        {
            if (texts[i].fontSize < minFontSize)
                minFontSize = texts[i].fontSize;
        }
        return minFontSize;
    }

    public static float GetAdjustedFontSize(Text[] texts)
    {
        float minFontSize = texts[0].fontSize;

        for (int i = 1; i < texts.Length; i++)
        {
            if (texts[i].fontSize < minFontSize)
                minFontSize = texts[i].fontSize;
        }
        return minFontSize;
    }

    public static float GetAdjustedFontSize(TMP_Text text, string[] messages)
    {
        text.text = messages[0];
        float minFontSize = text.fontSize;

        for (int i = 1; i < messages.Length; i++)
        {
            text.text = messages[i];
            if (text.fontSize < minFontSize)
                minFontSize = text.fontSize;
        }
        return minFontSize;
    }

    public static float GetAdjustedFontSize(Text text, string[] messages)
    {
        text.text = messages[0];
        float minFontSize = text.fontSize;

        for (int i = 1; i < messages.Length; i++)
        {
            text.text = messages[i];
            if (text.fontSize < minFontSize)
                minFontSize = text.fontSize;
        }
        return minFontSize;
    }
}
