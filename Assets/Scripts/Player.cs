using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movement Info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float doubleJumpForce;

    private bool canDoubleJump;


    private bool playerUnlocked;


    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorController();

        if (playerUnlocked)
            rb.linearVelocity = new Vector2(moveSpeed * 2, rb.linearVelocity.y);

        CheckCollision();
        CheckInput();
    }

    private void AnimatorController()
    {
        animator.SetBool("canDoubleJump", canDoubleJump);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("xVelocity", rb.linearVelocity.x);
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }
 
    private void CheckInput() 
    {

        if(Input.GetKeyDown(KeyCode.LeftShift))
            playerUnlocked = true;
        if (Input.GetKeyDown(KeyCode.Space))     
            JumpButton();
        

    }

    private void JumpButton()
    {
        if (isGrounded) 
        {
            canDoubleJump = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        } else if (canDoubleJump)
        {
            canDoubleJump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
