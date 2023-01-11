using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private Color _correctAnswerColor = new Color(0.386596f, 0.8584906f, 0.3199092f, 1f);
    private Color _wrongAnswerColor = new Color(0.6415094f, 0.3116768f, 0.3116768f, 1f);
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public void CheckAnswer()
    {
        if (_text.text == RiddleManager.GetCurrentRiddleAnswer())
        {         
            if (!RiddleManager.IsSelectedRiddleSolved())
                QuestProgressChanger.ChangeProgressCounter();
            _image.color = _correctAnswerColor;
        }
        else
            _image.color = _wrongAnswerColor;
    }

    public void SetColor(Color color) => _image.color = color;

    public void SetText(string text) => _text.text = text;
}
