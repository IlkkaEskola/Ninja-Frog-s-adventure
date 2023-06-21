using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //private int cherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource itemCollectSoundEffect;

    private void Start()
    {
        cherriesText.text = "Cherries: " + Scoring.totalScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            Scoring.totalScore ++;
            cherriesText.text = "Cherries: " + Scoring.totalScore;
            itemCollectSoundEffect.Play();
        }
    }
}
