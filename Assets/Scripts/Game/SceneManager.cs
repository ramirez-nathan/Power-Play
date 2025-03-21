using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  
    }

    public void LoadSelectModeMenu()
    {
        SceneManager.LoadScene("SelectMode");  
    }

    public void LoadGameplayScene()
    {
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
    }

    public void EndGame()
    {
        // Quit the application
        Application.Quit();

        // Debug message to confirm the function is called (only visible in the Unity editor)
        Debug.Log("Game has been quit.");
    }


}
