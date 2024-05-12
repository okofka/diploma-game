using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    { 
        Application.Quit();
    }

    public Button continueButton; // Посилання на кнопку продовження гри в інспекторі Unity

    void Start()
    {
        // Перевіряємо, чи є продовження гри доступним при запуску меню
        CheckContinueAvailability();
    }

    void CheckContinueAvailability()
    {
        PlayerData savedData = SaveSystem.LoadPlayer();
        if (savedData != null && savedData.level % 3 == 0) // Перевіряємо, чи існують збережені дані і чи є рівень кратний 3
        {
            continueButton.interactable = true; // Робимо кнопку продовження гри активною
        }
        else
        {
            continueButton.interactable = false; // Робимо кнопку продовження гри неактивною
        }
    }

    public void ContinueGame()
    {
        PlayerData savedData = SaveSystem.LoadPlayer();
        int savedSceneIndex = savedData.level;
        SceneManager.LoadScene(savedSceneIndex);
    }
}
