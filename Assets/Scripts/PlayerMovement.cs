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
    private float horizontalMovement;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool isGrounded;

    public Rigidbody2D rb2D;
    public Animator animator;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    [SerializeField] private Text livesText;

    [SerializeField] private AudioSource itemCollectSoundEffect;



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

        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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

        //if (gameObject.transform.position.y < -10)
        //{
            //Die();
            
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            Scoring.totalLives--;

            if(Scoring.totalLives < 0)
            {
                GameOver();
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

}








