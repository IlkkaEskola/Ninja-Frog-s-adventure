using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    public void Quit()
    {
        //Nollataan kirsikat, el‰m‰t ja aika, kun peli on p‰‰sty l‰pi
        PlayerMovement.totalCherries = 0;
        PlayerMovement.totalLives = 0;
        PlayerMovement.timeLeft = 120f;
        SceneManager.LoadScene("MainMenu");
    }
}




