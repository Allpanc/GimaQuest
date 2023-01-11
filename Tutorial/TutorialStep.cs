using UnityEngine;

public class TutorialStep : MonoBehaviour
{
    private bool _isCompleted;
    [SerializeField] private int _index;
    [SerializeField] private string _tutorialName;

    public bool GetCompleted() { return _isCompleted; }
    public void SetCompleted(bool value) { _isCompleted = value; }
    public int GetIndex() { return _index; }
    public string GetTutorialName() { return _tutorialName; }
}
