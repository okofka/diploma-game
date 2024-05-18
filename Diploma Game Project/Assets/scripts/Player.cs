using System.Collections;
using System.Collections.Generic;
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
    {
        if (level == 3)
        {
            SaveSystem.SavePlayer(this);
        }

        /* ��� ���� �'� ���� ��� ������, ��� � ��� ��� �� ���'�
        
        if (level % 3 == 0) // ����������, �� ����� ������� �����
        {
            PlayerData savedPlayerData = SaveSystem.LoadPlayer(); // ����������� ��� ������ ��������
            if (savedPlayerData == null || level > savedPlayerData.level) // ����������, �� ���� ���������� ����� ��� �� ����� ������
            {
                SaveSystem.SavePlayer(this); // ���� ���, �������� ������
            }
        }


        */
    }

    private void Awake()
    {
        inventory = new Inventory();
    }
}