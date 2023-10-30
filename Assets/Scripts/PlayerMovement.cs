using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //private int totalLives = 3;

    public float moveSpeed;
    public float jumpForce;
    private bool hasKey;

    public Transform playerTransform;
    public float wallJumpRayLength = 0.5f;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool isGrounded;

    public Rigidbody2D rb2D;
    public Animator animator;
    

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource itemCollectSoundEffect;
    [SerializeField] private AudioSource finishSound;

    [SerializeField] private Text livesText;

    


    //[SerializeField] private Text livesText;

    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        livesText.text = "Lives: " + Scoring.totalLives;
        


        //livesText.text = "Lives: " + totalLives;
    }


    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

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

        if(rb2D.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
        }

        
    }

   
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Scoring.totalLives--;
            Die();
     
            if(Scoring.totalLives < 0)
            {
                Invoke("GameOver", 2f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            Scoring.totalLives++;
            livesText.text = "Lives: " + Scoring.totalLives;
            itemCollectSoundEffect.Play();
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

    private void Die()
    {
        rb2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Die");
        moveSpeed = 0;
        deathSoundEffect.Play();
    }


    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}








