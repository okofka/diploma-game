using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    public void Start()
    {
        Player player = FindObjectOfType<Player>();
        Debug.Log("Player level: " + player.level);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = FindObjectOfType<Player>();

            if (sceneBuildIndex > PlayerPrefs.GetInt("level", 0))
            {
                PlayerPrefs.SetInt("level", sceneBuildIndex);
                PlayerPrefs.Save();
            }

            player.level = PlayerPrefs.GetInt("level", 0); // Оновлення рівня гравця з PlayerPref
            Debug.Log("Player level: " + player.level);

            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}

