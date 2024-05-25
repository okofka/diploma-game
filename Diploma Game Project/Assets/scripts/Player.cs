using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level;
    private Inventory inventory;

    public void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Player level: " + level);
    }

    private void Update()
    {/*
        if (level % 4 == 0)
        {
            SaveSystem.SavePlayer(this);
        }*/

        //��� ���� �'� ���� ��� ������, ��� � ��� ��� �� ���'�
        
        if (level % 4 == 0) // ����������, �� ����� ������� �����
        {
            string path = Application.persistentDataPath + "/player.fun";
            if (File.Exists(path))
            {
                PlayerData savedPlayerData = SaveSystem.LoadPlayer(); // ����������� ��� ������ ��������
                if (savedPlayerData == null || level > savedPlayerData.level) // ����������, �� ���� ���������� ����� ��� �� ����� ������
                {
                    SaveSystem.SavePlayer(this); // ���� ���, �������� ������
                }
            }
            else
            {
                SaveSystem.SavePlayer(this);
            }
        }

    }

    private void Awake()
    {
        inventory = new Inventory();
    }
}