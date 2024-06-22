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
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    private void Start()
    {
        CursurStartOptions();
        pauseAnimator = GameObject.Find("Player").GetComponent<Animator>();
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>();

        if (conversationUI != null)
            conversationUI.SetActive(true);
        
        getsceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (getsceneBuildIndex % 3 == 0 && getsceneBuildIndex == 18 || getsceneBuildIndex == 17)
                   CursurEndOptions();
        Debug.Log("scene " + getsceneBuildIndex);

    }

    void Update()
    {
        PausedKeyPressed();
        // якщо гра не на пауз≥, оновлюЇмо рух
        if (!GameIsPaused)
        {
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

        playerMovementScript.ResumeMovement();
        if (conversationUI != null)
        {
            CursurEndOptions();
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
            conversationUI.SetActive(false);
    }

    public void LoadMenu()
    {
        if (conversationUI != null)
            conversationUI.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        GameIsPaused = false;
        CursurEndOptions();
        playerMovementScript.ResumeMovement();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}