using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level;

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

        //тут буде н'ю лог≥к фор сейв≥нг, вен в≥ вил хев мо лвл'с
        
        if (level % 3 == 0) // ѕерев≥р€Їмо, чи р≥вень кратний трьом
        {
            string path = Application.persistentDataPath + "/player.fun";
            if (File.Exists(path))
            {
                PlayerData savedPlayerData = SaveSystem.LoadPlayer(); // «авантажуЇмо дан≥ гравц€ збережен≥
                if (savedPlayerData == null || level > savedPlayerData.level) // ѕерев≥р€Їмо, чи немаЇ збережених даних або чи р≥вень б≥льший
                {
                    SaveSystem.SavePlayer(this); // якщо так, збер≥гаЇмо гравц€
                }
            }
            else
            {
                SaveSystem.SavePlayer(this);
            }
        }

    }
}