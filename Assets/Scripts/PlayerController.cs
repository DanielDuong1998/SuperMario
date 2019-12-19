using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 6f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public int ourHealth;
    public int maxhealth = 111115;
    //public Vector3 respawnPoint;
    //public LevelManager gameLevelManager;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        ourHealth = maxhealth;
    }

    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);

        if(movement > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if(movement < 0)
        {
            transform.localScale = new Vector2(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y);

        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "FallDetector")
        //{
        //    //what will happen when player enters the FallDetector zo
        //    gameLevelManager.Respawn();
        //}
        //if (other.tag == "Checkpoint")
        //{
        //    respawnPoint = other.transform.position;
        //}
    }

    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("redFlash");
    }
}
