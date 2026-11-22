using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed;
    private float inputHorizontal;
    private Animator playerAnimator;
    public float jumpForce;
    private bool grounded;
    private GameManager gameManager;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movementSpeed * inputHorizontal, rb.linearVelocityY);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            grounded = false;
        }
    }

    //collision check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ground detection
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        
        //obstacle detection
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Death");
            gameManager.playerDeath();
        }

        

    }

    //triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //coin detection
        if (collision.gameObject.CompareTag("Coin"))
        {
            gameManager.coinCollection();
            Destroy(collision.gameObject);
        }
    }



}
