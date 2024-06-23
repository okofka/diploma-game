using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton; // ��������� �� ������ ����������� ��� � ��������� Unity

    void Start()
    {
        // ����������, �� � ����������� ��� ��������� ��� ������� ����
        CheckContinueAvailability();
        CursurEndOptions();
    }

    void CheckContinueAvailability()
    {
        // ����������, �� ���� ���� ����������
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            PlayerData savedData = SaveSystem.LoadPlayer();
            if (savedData != null && savedData.level % 3 == 0 || savedData.level == 17) // ����������, �� ������� �������� ��� � �� � ����� ������� 3
            {
                continueButton.interactable = true; // ������ ������ ����������� ��� ��������
                return;
            }
        }
        continueButton.interactable = false; // ������ ������ ����������� ��� ����������, ���� ����� ���� ��� ����� �� �������
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CursurStartOptions();
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
        CursurStartOptions();
    }
    private void CursurStartOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void CursurEndOptions()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
