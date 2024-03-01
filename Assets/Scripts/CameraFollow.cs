using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 0.2f;
    public Transform target;  //Kohteena pelaaja

    
    void Update()
    {
        //M‰‰ritet‰‰n kameran uusi sijainti
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        //Siirret‰‰n kameraa uuteen sijaintiin
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
