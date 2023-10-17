using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPoint; // alku piste
    public Transform endPoint;   // loppupiste
    public float speed = 2.0f;   // nopeus liikkuessa
    public float stoppingDistance = 0.1f; // pysäytys etäisyys

    private Vector3 currentTarget;
    private int direction = 1;

    //private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
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

            // käännä ympäri
            Vector3 newScale = transform.localScale;
            newScale.x = direction;
            transform.localScale = newScale;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        //animator.SetBool("Scorpion", true);
    }
}
