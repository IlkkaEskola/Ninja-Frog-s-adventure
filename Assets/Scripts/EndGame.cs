using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    public void Quit()
    {
        Cherries.totalCherries = 0;
        Lives.totalLives = 0;
        TimeCounter.timeLeft = 90f;
        SceneManager.LoadScene("MainMenu");
    }
}
