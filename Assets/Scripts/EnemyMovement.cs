using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPoint; //Alku piste
    public Transform endPoint;   //Loppupiste
    public float speed = 2.0f;   
    public float stoppingDistance = 0.1f; //Pys�ytys et�isyys

    private Vector3 currentTarget;
    private int direction = 1;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentTarget = endPoint.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) < stoppingDistance)
        {
            if (currentTarget == endPoint.position)
            {
                currentTarget = startPoint.position;
                direction = -1;
            }
            else
            {
                currentTarget = endPoint.position;
                direction = 1;
            }

            // k��ntyy ymp�ri
            Vector3 newScale = transform.localScale;
            newScale.x = direction;
            transform.localScale = newScale;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        
    }
}
