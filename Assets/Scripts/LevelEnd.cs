using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private TMP_Text briefText;
    [SerializeField] private string nextLevelName;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (LevelManager.Instance.HasKey())
            {        
                if (nextLevelName != "GameOver")
                {
                    SoundManager.Instance.PlayLevelCompleteSound();
                }
                else
                {
                    SoundManager.Instance.PlayGameCompleteSound();
                    
                    TimerController timerController = FindObjectOfType<TimerController>();
                    if (timerController != null)
                    {
                        timerController.StopTimer();
                    }
                    
                    LeaderboardManager leaderboardManager = FindObjectOfType<LeaderboardManager>();
                    if (leaderboardManager != null)
                        leaderboardManager.AddNewScore();
                }
                
                // Debugging: Check if the CompletionTime key exists and log its value
                if (PlayerPrefs.HasKey("CompletionTime"))
                {
                    float savedCompletionTime = PlayerPrefs.GetFloat("CompletionTime");
                    Debug.Log("Completion Time loaded: " + savedCompletionTime);
                }
                else
                {
                    Debug.Log("No Completion Time found in PlayerPrefs at level:" + nextLevelName);
                }
                
                SceneManager.LoadScene(nextLevelName);

            }
            else
                ShowBriefText("You need to find the key first!");
        }
    }

    private void ShowBriefText(string message)
    {
        briefText.text = message;
        briefText.gameObject.SetActive(true);
        StartCoroutine(HideBriefTextAfterDelay(2f));
    }

    private IEnumerator HideBriefTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        briefText.gameObject.SetActive(false);
    }
}