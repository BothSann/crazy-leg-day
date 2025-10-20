using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    [Header("Movement Info")]
    public float moveSpeed;
    public float jumpForce;


    [Header("Collision Info")]
    public float groundCheckDistance;
    public LayerMask groundLayer;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        CheckCollision();
        CheckInput();
    }
    
    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void CheckInput() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
