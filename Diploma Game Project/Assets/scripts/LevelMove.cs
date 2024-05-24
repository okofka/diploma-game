using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    private int sceneBuildIndex;
    private bool playerInTrigger;

    private void Start()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            sceneBuildIndex = nextSceneIndex;
        }
        else
        {
            sceneBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}