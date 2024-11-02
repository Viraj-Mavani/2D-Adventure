using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Transform leaderboardContent;
    public GameObject leaderboardEntryPrefab;
    public GameObject leaderboardPanel;
    private List<(string, float)> leaderboard = new List<(string, float)>();
    
    private void Start()
    {
        LoadLeaderboard();
    }

    public void AddNewScore()
    {
        string username = PlayerPrefs.GetString("Username");
        float completionTime = PlayerPrefs.GetFloat("CompletionTime");

        if (string.IsNullOrEmpty(username) || completionTime == 0)
        {
            Debug.LogError("No username or completion time found.");
            return;
        }
        
        Debug.Log($"Adding score: {username} - {completionTime}");
        leaderboard.Add((username, completionTime));
        leaderboard.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        Debug.Log($"Added score: {username} - {completionTime:F2}");

        SaveLeaderboard();
        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }
        
        Debug.Log("Displaying leaderboard entries...");

        foreach (var entry in leaderboard)
        {
            Debug.Log($"Username: {entry.Item1}, Time: {entry.Item2}");

            GameObject newEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);
            TMP_Text entryText = newEntry.GetComponent<TMP_Text>();
            if (entryText != null)
            {
                entryText.text = $"{entry.Item1}: {entry.Item2:F2} seconds";
            }
            else
            {
                Debug.LogError("Leaderboard entry prefab is missing a Text component.");
            }
        }
        Debug.Log($"Total entries displayed: {leaderboard.Count}");
        Debug.Log($"leaderboard: {leaderboard}");
    }

    public void LoadLeaderboard()
    {
        leaderboard.Clear();
        
        Debug.Log("Loading leaderboard entries...");
        
        for (int i = 0; i < 10; i++)
        {
            string username = PlayerPrefs.GetString($"Leaderboard_Username_{i}", "");
            float time = PlayerPrefs.GetFloat($"Leaderboard_Time_{i}", float.MaxValue);

            if (!string.IsNullOrEmpty(username))
            {
                leaderboard.Add((username, time));
                Debug.Log($"Loaded leaderboard entry: {username} - {time:F2} seconds");
            }
        }
        Debug.Log($"Total leaderboard entries loaded: {leaderboard.Count}");
    }

    private void SaveLeaderboard()
    {
        for (int i = 0; i < leaderboard.Count && i < 10; i++)
        {
            PlayerPrefs.SetString($"Leaderboard_Username_{i}", leaderboard[i].Item1);
            PlayerPrefs.SetFloat($"Leaderboard_Time_{i}", leaderboard[i].Item2);
        }
        PlayerPrefs.Save();
        
        // Debugging: Log the PlayerPrefs entries
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"PlayerPrefs Entry - Username: {PlayerPrefs.GetString($"Leaderboard_Username_{i}")}, Time: {PlayerPrefs.GetFloat($"Leaderboard_Time_{i}")}");
        }
    }
    
    public void ShowLeaderboard()
    {
        if (leaderboardPanel != null)
        {
            leaderboardPanel.SetActive(true);
            LoadLeaderboard();
            DisplayLeaderboard();
        }
    }

    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);
    }
}