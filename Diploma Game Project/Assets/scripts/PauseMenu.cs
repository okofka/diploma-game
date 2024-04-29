using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public int sceneBuildIndex;

    private Animator pauseAnimator;

    private PlayerMovementScript playerMovementScript; // Додайте посилання на скрипт PlayerMovementScript

    private void Start()
    {
        pauseAnimator = GameObject.Find("Player").GetComponent<Animator>();
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;

        // Отримайте доступ до скрипту PlayerMovementScript
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        PausedKeyPressed();
        // Якщо гра не на паузі, оновлюємо рух
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        playerMovementScript.ResumeMovement();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}