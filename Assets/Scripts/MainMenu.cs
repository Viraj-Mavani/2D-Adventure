using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
    
public class MainManu : MonoBehaviour
{
    public GameObject levelSelectionPanel;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public TMP_Text greetingText;
    
    private void Start()
    {
        string username = PlayerPrefs.GetString("Username", "Player"); 

        if (greetingText != null)
            greetingText.text = $"Hey! {username}";
        else
        {
            Debug.LogError("TMP_Text component not assigned to greetingText.");
            greetingText.text = "Hey! Player";
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void LoadGame()
    {
        levelSelectionPanel.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    
    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
    }
}