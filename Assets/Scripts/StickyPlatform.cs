using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Tehd‰‰n pelaajasta Platformin parent objekti, jolloin pelaaja pysyy Platformilla
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Poistetaan parent, jolloin pelaaja ei pysy Platformilla
            collision.gameObject.transform.SetParent(null);
        }
    }
}
