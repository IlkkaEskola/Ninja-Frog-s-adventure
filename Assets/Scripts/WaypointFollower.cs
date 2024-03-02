using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //Pisteet, joiden välillä liikutaan
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        //Tarkistetaan ollaanko lähellä nykyistä kohdepistettä
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            //Siirrytään seuraavaan kohdepisteeseen
            currentWaypointIndex++;

            //Jos ollaan saavutettu viimeinen kohdepiste, palataan ensimmäiseen
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        //Liikutetaan objektia kohti nykyistä kohdepistettä
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
