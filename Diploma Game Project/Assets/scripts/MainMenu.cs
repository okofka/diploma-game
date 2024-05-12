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

    public Button continueButton; // ��������� �� ������ ����������� ��� � ��������� Unity

    void Start()
    {
        // ����������, �� � ����������� ��� ��������� ��� ������� ����
        CheckContinueAvailability();
    }

    void CheckContinueAvailability()
    {
        PlayerData savedData = SaveSystem.LoadPlayer();
        if (savedData != null && savedData.level % 3 == 0) // ����������, �� ������� �������� ��� � �� � ����� ������� 3
        {
            continueButton.interactable = true; // ������ ������ ����������� ��� ��������
        }
        else
        {
            continueButton.interactable = false; // ������ ������ ����������� ��� ����������
        }
    }

    public void ContinueGame()
    {
        PlayerData savedData = SaveSystem.LoadPlayer();
        int savedSceneIndex = savedData.level;
        SceneManager.LoadScene(savedSceneIndex);
    }
}
