using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    private int sceneBuildIndex;
    private bool playerInTrigger;
    private DoorScript doorScript;

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

        GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
        if (doorObject != null)
        {
            doorScript = doorObject.GetComponent<DoorScript>();
        }
        else
        {
            Debug.LogWarning("Door object not found or does not have a DoorScript component.");
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
        if (playerInTrigger)
        {
            if (doorScript != null && !doorScript.locked)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
            else
            {
                Debug.Log("Door is locked or doorScript is null.");
            }
        }
    }
}
