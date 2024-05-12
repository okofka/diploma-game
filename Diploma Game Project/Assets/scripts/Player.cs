using System.Collections;
using System.Collections.Generic;
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
    {
        if (level == 3)
        {
            SaveSystem.SavePlayer(this);
        }
    }
}