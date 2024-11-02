using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPanel; 
    private TimerController timerController;
    private LeaderboardManager leaderboardManager;

    private void Start()
    {
        timerController = FindObjectOfType<TimerController>();
        leaderboardManager = FindObjectOfType<LeaderboardManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && levelSelectionPanel.activeSelf)
            HideLevelSelection();
    }
    
    public void LoadLevel(string levelName)
    {
        if (levelName == "GameOver")
        {
            SoundManager.Instance.PlayGameCompleteSound();

            float completionTime = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("CompletionTime", completionTime);
            Debug.Log("Completion Time saved: " + completionTime);

            LeaderboardManager leaderboardManager = FindObjectOfType<LeaderboardManager>();
            if (leaderboardManager != null)
                leaderboardManager.AddNewScore();
            
            PlayerPrefs.Save();
        }
        
        // Debugging: Check if the CompletionTime key exists and log its value
        if (PlayerPrefs.HasKey("CompletionTime"))
        {
            float savedCompletionTime = PlayerPrefs.GetFloat("CompletionTime");
            Debug.Log("Completion Time loaded: " + savedCompletionTime);
        }
        else
        {
            Debug.Log("No Completion Time found in PlayerPrefs.");
        }

        Debug.Log("Loading Level:" + levelName);
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
        PauseManu.isPaused = false;
    }

    public void ShowLevelSelection()
    {
        gameObject.SetActive(true);
    }

    public void HideLevelSelection()
    {
        gameObject.SetActive(false);
    }
    
    public void ToggleLevelSelection()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}