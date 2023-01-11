using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesManager : MonoBehaviour
{
    #region "Fields"

    private List<Note> _notes = new List<Note>();

    [SerializeField] private NoteDisplay _noteDisplay;
    [SerializeField] private GameObject _noteInformationPanel;
    [SerializeField] private GameObject _aboutPanel;
    [SerializeField] private Button[] _noteButtons;
    [SerializeField] private Camera _notesRenderCamera;

    #endregion

    private void Start()
    {
        _notes = JsonMaster.ParseResource<Note>("Notes");
        QuestProgressChanger.OnProgressCounterChanged.AddListener(UnlockNextNote);
    }

    public void DisplayNote(int index)
    {
        _notesRenderCamera.enabled = true;
        _noteInformationPanel.SetActive(true);
        _noteDisplay.SetNoteInformation(_notes[index], index);
    }

    public void ShowAboutInfo() => _aboutPanel.SetActive(true);

    public void HideAboutInfo() =>_aboutPanel.SetActive(false);

    public void CloseNote()
    {
        _notesRenderCamera.enabled = false;
        _noteDisplay.ResetDisplay();
        _noteInformationPanel.SetActive(false);
    }

    private void UnlockNextNote()
    {
        if (QuestProgressChanger._progressCounter <= _notes.Count)
            _noteButtons[QuestProgressChanger._progressCounter-1].interactable = true;
    }

    private void SaveNotes()
    {
        //_notes.Add(new Note("Бурый медведь 1", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //_notes.Add(new Note("Бурый медведь 2", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //_notes.Add(new Note("Бурый медведь 3", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //_notes.Add(new Note("Бурый медведь 4", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //_notes.Add(new Note("Бурый медведь 5", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //_notes.Add(new Note("Бурый медведь 6", "Масса: 80 – 600 кг (взрослая особь)\nПродолжительность жизни: 20 – 30 лет\nСкорость: 56 км / ч(максимум)\nРост: 70 – 150 см(взрослая особь, в плечах)\nДлина: 1, 4 – 2, 8 м(взрослая особь)", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new string[] { "Спит зимой", "Летом не спит" }));
        //JsonMaster.Save(_notes, "Notes.json");
    }
}
