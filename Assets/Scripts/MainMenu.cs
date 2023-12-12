using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
        
    
}
