using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{/*
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);*/

    public Button continueButton; // Посилання на кнопку продовження гри в інспекторі Unity

    void Start()
    {
        // Перевіряємо, чи є продовження гри доступним при запуску меню
        CheckContinueAvailability();/*
        CursurEndOptions();*/
    }

    private void Update()
    {/*
        Cursor.visible = true;*/
    }

    void CheckContinueAvailability()
    {
        // Перевіряємо, чи існує файл збереження
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            PlayerData savedData = SaveSystem.LoadPlayer();
            if (savedData != null && savedData.level % 3 == 0) // Перевіряємо, чи існують збережені дані і чи є рівень кратний 3
            {
                continueButton.interactable = true; // Робимо кнопку продовження гри активною
                return;
            }
        }
        continueButton.interactable = false; // Робимо кнопку продовження гри неактивною, якщо файлу немає або умови не виконані
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        PlayerData savedData = SaveSystem.LoadPlayer();
        if (savedData != null)
        {
            int savedSceneIndex = savedData.level;
            SceneManager.LoadScene(savedSceneIndex);
        }
    }
    /*
    private void CursurEndOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        SetCursorPositionToCenter();
    }

    private void SetCursorPositionToCenter()
    {
        int xPos = Screen.width / 2;
        int yPos = Screen.height / 2;
        SetCursorPos(xPos, yPos);
    }*/
}
