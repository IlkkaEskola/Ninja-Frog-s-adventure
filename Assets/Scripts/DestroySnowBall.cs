using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySnowBall : MonoBehaviour
{
    public ParticleSystem snowballHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        snowballHit.Play();
        Destroy(gameObject, 0.5f);  //Pieni lumipallo
    }
}
