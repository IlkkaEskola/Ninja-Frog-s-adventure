using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void Quit()
    {
        Cherries.totalCherries = 0;
        Scoring.totalLives = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
