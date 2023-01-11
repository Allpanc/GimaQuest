using UnityEngine;

public class MapProgressChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _mapSteps;

    void Start()
    {
        QuestProgressChanger.OnProgressCounterChanged.AddListener(ChangeMapProgress);
        QuestProgressChanger.OnQuestFullyCompleted.AddListener(CompleteMapProgress);
        ResetMapProgress();
        ChangeMapProgress();
    }

    private void ChangeMapProgress()
    {
        if (QuestProgressChanger._progressCounter < _mapSteps.Length)
        {
            _mapSteps[QuestProgressChanger._progressCounter].SetActive(true);
            Debug.LogWarning("Map changed, step " + QuestProgressChanger._progressCounter + " activated");
        }
    }

    private void CompleteMapProgress()
    {
        _mapSteps[_mapSteps.Length-1].SetActive(true);
        Debug.LogWarning("Map changed, step " + (_mapSteps.Length - 1) + " activated");
    }

    private void ResetMapProgress()
    {
        foreach (GameObject step in _mapSteps)
            step.SetActive(false);
        Debug.LogWarning("Reset map");
    }
}
