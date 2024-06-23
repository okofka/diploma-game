using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int sceneBuildIndex;
    public int getsceneBuildIndex;
    private Animator pauseAnimator;
    private PlayerMovementScript playerMovementScript; // ƒодайте посиланн€ на скрипт PlayerMovementScript
    public GameObject conversationUI;
    private CharacterManager characterManager;

    private void Start()
    {
        CursurStartOptions();
        GameObject pauseAnimatorObject = GameObject.Find("Player");
        if (pauseAnimatorObject != null)
        {
            pauseAnimator = pauseAnimatorObject.GetComponent<Animator>();
            pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        GameObject characterTableObject = GameObject.Find("Character-table");
        if (characterTableObject != null)
        {
            characterManager = characterTableObject.GetComponent<CharacterManager>();
        }
        GameObject playerMovementObject = GameObject.Find("Player");
        if (playerMovementObject != null)
        {
            playerMovementScript = playerMovementObject.GetComponent<PlayerMovementScript>();
        }

        if (conversationUI != null)
            conversationUI.SetActive(true);
    }

    void Update()
    {
        PausedKeyPressed();
        // якщо гра не на пауз≥, оновлюЇмо рух
        if (!GameIsPaused)
        {
            if(playerMovementScript != null)
                playerMovementScript.UpdateMovement();
        }
    }

    public void PausedKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
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

    public void Resume()
    {
        CursurStartOptions();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        if(playerMovementScript != null)
            playerMovementScript.ResumeMovement();
        if (conversationUI != null)
        {
            if (characterManager.playerInTrigger == true)
                CursurEndOptions();
            else
                CursurStartOptions();
            conversationUI.SetActive(true);
        }
    }

    public void Pause()
    {
        CursurStartOptions();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (conversationUI != null)
        {
            if (characterManager.playerInTrigger == true)
                CursurEndOptions();
            else
                CursurStartOptions();
            conversationUI.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        if (conversationUI != null)
            conversationUI.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        GameIsPaused = false;
        CursurEndOptions();
        if(playerMovementScript != null)
            playerMovementScript.ResumeMovement();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}