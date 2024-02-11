using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Destroy(gameObject, 2.2f);
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    
}
