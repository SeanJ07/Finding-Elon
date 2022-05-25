using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;
    int direction = 1;
    public float speed;
    public float jumpForce;

    private float moveInput;
   private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool vertical;
    private bool isJumping;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput< 0 && facingRight)
        {
            Flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            animator.SetBool ("IsJumping", true);
           
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > .01)
            {
              rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false; 
        }
        if (isGrounded == false && jumpTimeCounter !> .01 && isJumping == false)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

     void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
