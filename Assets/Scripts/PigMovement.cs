using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public Transform startPoint; //Alkupiste
    public Transform endPoint;   //Loppupiste
    public float speed = 2.0f;   
    public float stoppingDistance = 0.1f; //Pys‰ytys et‰isyys
    
    public float jumpForce = 6f;
    public float jumpInterval = 3f;  //Aika hyppyjen v‰lill‰
    private bool isJumping = false;
    private float jumpTimer = 0f;

    private Vector3 currentTarget;
    private int direction = 1;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        currentTarget = endPoint.position;
    }

    void Update()
    {
        Movement();
        UpdateJump();
    }

    private void Movement()
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

            // k‰‰ntyy ymp‰ri
            Vector3 newScale = transform.localScale;
            newScale.x = direction;
            transform.localScale = newScale;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void UpdateJump()
    {
        //P‰ivitet‰‰n hyppyjen aikav‰li‰
        jumpTimer += Time.deltaTime;

        //Tarkistetaan onko hyppyjen aikav‰li kulunut
        if (jumpTimer >= jumpInterval)
        {
            //Hyp‰t‰‰n ja nollataan hyppyjen aikav‰li
            Jump();
            jumpTimer = 0f;
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            StartCoroutine(ResetJump());
        }
    }

    IEnumerator ResetJump()
    {
        //Estet‰‰n jatkuva hyppiminen pienell‰ viiveell‰, nollaamalla isJumping muuttuja
        yield return new WaitForSeconds(0.5f);  
        isJumping = false;
    }
}


