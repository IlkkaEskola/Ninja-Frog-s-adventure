using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public Transform startPoint; // alku piste
    public Transform endPoint;   // loppupiste
    public float speed = 2.0f;   // nopeus liikkuessa
    public float stoppingDistance = 0.1f; // pysäytys etäisyys
    
    public float jumpForce = 6f;
    public float jumpInterval = 3f;
    private bool isJumping = false;
    private float jumpTimer = 0f;

    private Vector3 currentTarget;
    private int direction = 1;

    //private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
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

        jumpTimer += Time.deltaTime;

        if (jumpTimer >= jumpInterval)
        {
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
        yield return new WaitForSeconds(0.5f); // Adjust as needed
        isJumping = false;
    }
}


