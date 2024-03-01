using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPoint; //Alku piste
    public Transform endPoint;   //Loppupiste
    public float speed = 2.0f;   
    public float stoppingDistance = 0.1f; //Pysäytys etäisyys

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
        Movement();
    }

    private void Movement()
    {
        //Tarkistetaan, onko vihollinen saavuttanut nykyisen kohteen
        if (Vector3.Distance(transform.position, currentTarget) < stoppingDistance)
        {
            //Jos nykyinen kohde on loppupiste, vaihdetaan kohde alkupisteeksi ja vaihdetaan suunta
            if (currentTarget == endPoint.position)
            {
                currentTarget = startPoint.position;
                direction = -1;
            }
            //Muussa tapauksessa vaihdetaan kohde loppupisteeksi ja vaihdetaan suunta
            else
            {
                currentTarget = endPoint.position;
                direction = 1;
            }

            //Käännetään vihollinen ympäri
            Vector3 newScale = transform.localScale;
            newScale.x = direction;
            transform.localScale = newScale;
        }

        //Liikutetaan vihollista kohti nykyistä kohdetta
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
