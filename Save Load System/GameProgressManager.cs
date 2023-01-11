using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameProgressManager : MonoBehaviour
{

    public static UnityEvent OnQuestProgressLoaded = new UnityEvent();
    public static UnityEvent OnCreativeModeLoaded = new UnityEvent();
    public static UnityEvent OnMainPartFullyCompletedLoaded= new UnityEvent();
    public static UnityEvent OnGameProgressCleared = new UnityEvent();

    private string _isStarted = "Start Completed";
    private string _isMainlyCompleted = "Quest Mainly Completed";
    private string _isFullyCompleted = "Quest Fully Completed";
    private string _progressCounter = "Progress Counter";

    void Start()
    {
        WelcomeTutorial.OnStartTargetFoundCompleted.AddListener(UpdateGameProgress);
        QuestProgressChanger.OnProgressCounterChanged.AddListener(UpdateGameProgress);
        QuestProgressChanger.OnQuestMainPartCompleted.AddListener(UpdateGameProgress);
        QuestProgressChanger.OnQuestFullyCompleted.AddListener(UpdateGameProgress);
        OnGameProgressCleared.AddListener(QuestProgressChanger.ResetProgressCounter);
        //ClearGameProgress();
        LoadGameProgress();
    }

    private void LoadGameProgress()
    {
        InitializePlayerPrefs();
        if (PlayerPrefs.GetString(_isStarted) == "No")
            return;

        OnQuestProgressLoaded.Invoke();

        for (int i = 0; i < PlayerPrefs.GetInt(_progressCounter); i++)
            QuestProgressChanger.ChangeProgressCounter();

        if (PlayerPrefs.GetString(_isFullyCompleted) == "Yes")
        {
            OnMainPartFullyCompletedLoaded.Invoke();
            OnCreativeModeLoaded.Invoke();
        }
        
        Debug.LogWarning("Load game progress");
    }

    private void UpdateGameProgress()
    {
        if (PlayerPrefs.GetString(_isStarted) == "No")
            PlayerPrefs.SetString(_isStarted, "Yes");
      
        if (QuestProgressChanger._progressCounter > PlayerPrefs.GetInt(_progressCounter))
            PlayerPrefs.SetInt(_progressCounter, QuestProgressChanger._progressCounter);

        if (PlayerPrefs.GetString(_isMainlyCompleted) == "No" && QuestProgressChanger._isMainlyCompleted)
            PlayerPrefs.SetString(_isMainlyCompleted, "Yes");
        
        if (PlayerPrefs.GetString(_isFullyCompleted) == "No" && QuestProgressChanger._isFullyCompleted)
            PlayerPrefs.SetString(_isFullyCompleted, "Yes");

        PlayerPrefs.Save();
        Debug.LogWarning("Update game progress");
        //Debug.LogWarning(PlayerPrefs.GetString(_isStarted));
    }

    private void InitializePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(_isStarted))
        {
            PlayerPrefs.SetString(_isStarted, "No");
            PlayerPrefs.SetString(_isMainlyCompleted, "No");
            PlayerPrefs.SetString(_isFullyCompleted, "No");
            PlayerPrefs.SetInt(_progressCounter, 0);
            PlayerPrefs.Save();
        }
    }

    public void ClearGameProgress()
    {
        OnGameProgressCleared.Invoke();
        PlayerPrefs.SetString(_isStarted, "No");
        PlayerPrefs.SetString(_isMainlyCompleted, "No");
        PlayerPrefs.SetString(_isFullyCompleted, "No");
        PlayerPrefs.SetInt(_progressCounter, 0);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Debug.LogWarning("Clear game progress");
    }
}
