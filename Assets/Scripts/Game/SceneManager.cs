using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip MainMenuMusicPinkBloom;

    // Start is called before the first frame update
    void Start()
    {
        

        // Only start music if it's not already playing
        if (AudioManager.Instance != null)
        {
            if (AudioManager.Instance.musicSource.isPlaying == false)
            {
                AudioManager.Instance.PlayBackgroundMusic(MainMenuMusicPinkBloom);
                AudioManager.Instance.SetMusicVolume(0.15f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        if (AudioManager.Instance != null) AudioManager.Instance.PlayBackgroundMusic(MainMenuMusicPinkBloom);
        SceneManager.LoadScene("MainMenu");  
    }

    public void LoadSelectModeMenu()
    {
        SceneManager.LoadScene("SelectMode");  
    }

    public void LoadGameplayScene()
    {
        AudioManager.Instance.StopBackgroundMusic();
        SceneManager.LoadScene("Game");  
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadStageSelection()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void LoadCharacterCustomization()
    {
        SceneManager.LoadScene("CharacterCustomizer");
    }

    public void LoadStatsScreen()
    {
        SceneManager.LoadScene("StatsScreen");
        // Only start music if it's not already playing
        if (AudioManager.Instance.musicSource.isPlaying == false)
        {
            AudioManager.Instance.PlayBackgroundMusic(MainMenuMusicPinkBloom);
            AudioManager.Instance.SetMusicVolume(0.15f);
        }
    }

    public void EndGame()
    {
        // Quit the application
        Application.Quit();

        // Debug message to confirm the function is called (only visible in the Unity editor)
        Debug.Log("Game has been quit.");
    }

    public IEnumerator SwitchToStatsScene()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("StatsScreen");
    }
}
