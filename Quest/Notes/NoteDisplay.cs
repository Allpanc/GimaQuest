using TMPro;
using UnityEngine;
using System.Collections;

public class NoteDisplay : MonoBehaviour
{
    #region "Fields"

    [Header("Titles")]
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _parametersTitle;
    [SerializeField] private TMP_Text _descriptionTitle;
    [SerializeField] private TMP_Text _factsTitle;

    [Header("Texts")]
    [SerializeField] private TMP_Text _mainParameters;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _interestingFacts;

    [Header("Animals")]
    [SerializeField] private GameObject[] _animals;

    private TMP_Text[] _titles;
    private TMP_Text[] _texts;
    private Vector2[] _initialRectSizes;

    #endregion

    private void Start()
    {
        _titles = new TMP_Text[] { _title, _parametersTitle, _descriptionTitle, _factsTitle };
        AdjustTitlesFontSize();

        _texts = new TMP_Text[] { _mainParameters, _description, _interestingFacts };
        _initialRectSizes = new Vector2[] { _mainParameters.gameObject.GetComponent<RectTransform>().sizeDelta ,
                                            _description.gameObject.GetComponent<RectTransform>().sizeDelta,
                                            _interestingFacts.gameObject.GetComponent<RectTransform>().sizeDelta};
    }

    public void SetNoteInformation(Note note, int animalIndex)
    {
        foreach (GameObject animal in _animals)
            animal.SetActive(false);
        _animals[animalIndex].SetActive(true);

        _title.text = note._title;
        _mainParameters.text = note._mainParameters;
        _description.text = note._description;

        string facts = "";
        for (int i = 0; i < note._interestingFacts.Length; i++)
        {
            facts += note._interestingFacts[i];
            if (i != note._interestingFacts.Length - 1)
                facts += "\n";
        }
        _interestingFacts.text = facts;
        StartCoroutine(AdjustTextsFontSize());
    }

    public void ResetDisplay()
    {
        foreach (GameObject animal in _animals)
            animal.SetActive(false);
        ResetAutoSizing();
    }

    #region("Auto Sizing")

    private void ResetAutoSizing()
    {
        foreach (TMP_Text text in _texts)
            text.enableAutoSizing = true;

        for (int i = 0; i < _texts.Length; i++)
            _texts[i].gameObject.GetComponent<RectTransform>().sizeDelta = _initialRectSizes[i];
    }

    IEnumerator AdjustTextsFontSize()
    {
        yield return null;

        float adjustedSize = FontSizeAdjustHelper.GetAdjustedFontSize(_texts);
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].enableAutoSizing = false;
            _texts[i].fontSize = adjustedSize;
            Vector2 currentRectSize = _texts[i].gameObject.GetComponent<RectTransform>().sizeDelta;
            _texts[i].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(currentRectSize.x, _texts[i].preferredHeight);
        }
    }

    private void AdjustTitlesFontSize()
    {
        float adjustedSize = FontSizeAdjustHelper.GetAdjustedFontSize(_titles);
        for (int i = 0; i < _titles.Length; i++)
        {
            _titles[i].enableAutoSizing = false;
            _titles[i].fontSize = adjustedSize;
        }
    }
    #endregion
}
