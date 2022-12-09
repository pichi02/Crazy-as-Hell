using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;

public class PauseScene : MonoBehaviour
{

    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;

    public static event Action OnPause;
    public static event Action OnResume;
    private static bool canPause = false;

    private void Awake()
    {
        canPause = false;
    }

    private void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                    Resume();
                else
                    Pause();
            }
        }
    }

    public void Resume()
    {
        OnResume?.Invoke();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AkSoundEngine.PostEvent("Resume_car_engine", gameObject);
    }

    public void Pause()
    {
        OnPause?.Invoke();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AkSoundEngine.PostEvent("Pause_car_engine", gameObject);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void EnableCanPause()
    {
        canPause = true;
    }
}
