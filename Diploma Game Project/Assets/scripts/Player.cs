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
}