using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float iceSpeed;
    public float jumpForce;
    private bool hasKey;

    public Transform playerTransform;
    //public float wallJumpRayLength = 0.5f;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool isGrounded;

    public bool onIce = false;

    private Rigidbody2D rb2D;
    private Animator animator;
    
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource itemCollectSoundEffect;
    [SerializeField] private AudioSource finishSound;

    [SerializeField] private Text livesText;
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text timeText;



    void Start()
    {
        iceSpeed = moveSpeed * 2f;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        livesText.text = "Lives: " + Lives.totalLives;
        cherriesText.text = "Cherries: " + Cherries.totalCherries;
        timeText.text = "Time: " + TimeCounter.timeLeft;

        StartCoroutine(TimeRemaining());
    }


    private void Update()
    {
        if (!onIce)
        {
            transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(Input.GetAxis("Horizontal") * iceSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Joko a tai d pohjassa
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && onIce)
        {
            animator.SetBool("Slide", true);
        }
        else
        {
            animator.SetBool("Slide", false);
        }


        //Tarkistetaan onko pelaaja maassa
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");
            jumpSoundEffect.Play();
        }

        
        //Pelaaja kuolee, jos putoaa kielekkeeltä
        /*if (transform.position.y < -8)
        {
            Cherries.totalCherries = 0;
            Lives.totalLives--;
            FallDeath();

            if (Lives.totalLives < 0)
            {
                Invoke("GameOver", 2f);
            }
        }*/

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
     
            if(Lives.totalLives < 0)
            {
                Invoke("GameOver", 2f);
            }
        }

        if (collision.gameObject.CompareTag("SnowBall"))
        {
            Die();

            if (Lives.totalLives < 0)
            {
                Invoke("GameOver", 2f);
            }
        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            onIce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            onIce = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            Cherries.totalCherries++;
            cherriesText.text = "Cherries: " + Cherries.totalCherries;
            itemCollectSoundEffect.Play();

            if(Cherries.totalCherries == 5)
            {
                Cherries.totalCherries = 0;
                cherriesText.text = "Cherries: " + Cherries.totalCherries;
                Lives.totalLives++;
                livesText.text = "Lives: " + Lives.totalLives;
            }
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
            itemCollectSoundEffect.Play();
        }
        
        if (collision.gameObject.CompareTag("Gate") && hasKey)
        {
            finishSound.Play();
            Invoke("LevelComplete", 2f);
        }
    }

    IEnumerator TimeRemaining()
    {
        while(TimeCounter.timeLeft > 0) 
        {
            timeText.text = "Time: " + TimeCounter.timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            TimeCounter.timeLeft--;
        }

        if(TimeCounter.timeLeft <= 0) 
        {
            Die();

            if (Lives.totalLives < 0)
            {
                Invoke("GameOver", 2f);
            }
        }
    }
    /*private void TimeRemaining()
    {
        if (TimeCounter.timeLeft > 0)
        {
            TimeCounter.timeLeft -= Time.deltaTime;
            timeText.text = "Time: " + TimeCounter.timeLeft;
        }
    }*/

    private void Die()
    {
        rb2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Die");
        moveSpeed = 0;
        deathSoundEffect.Play();
        Cherries.totalCherries = 0;
        Lives.totalLives--;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        TimeCounter.timeLeft = 120f;
    }
    
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        TimeCounter.timeLeft = 120f;
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        TimeCounter.timeLeft = 120f;
    }

}








