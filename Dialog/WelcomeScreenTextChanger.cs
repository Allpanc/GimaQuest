using UnityEngine;
using TMPro;

public class WelcomeScreenTextChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text _welcomeScreenText;
    private string[] _messages;

    void Start()
    {
        _messages = JsonMaster.ParseResource<string>("WelcomeTexts").ToArray();

        if (PlayerPrefs.GetString("Start Completed") == "Yes")
            _welcomeScreenText.text = _messages[1];
        else
            _welcomeScreenText.text = _messages[0];
    }
}
