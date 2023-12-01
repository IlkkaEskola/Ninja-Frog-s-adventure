using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused) 
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
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Cherries.totalCherries = 0;
        Lives.totalLives = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
