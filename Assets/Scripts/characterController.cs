using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontalInput;
    bool walking;
    bool onGround;

    public string nextLevel;
    public bool facingRight = true;

    public float jumpForce = 10f;
    public float fallGrav;

    [Header("Collision Checks")]
    public GameObject groundCheckLeft;
    public GameObject groundCheckRight;
    public float groundCheckLength;
    public GameObject groundCheckCircle;
    public float groundCheckCircleRadius;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void takeInput()
    {
        Vector3 mousePos = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x, Camera.main.ScreenPointToRay(Input.mousePosition).origin.y, 0);


        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(mousePos.x < transform.position.x && facingRight) { flip();  }
        else if (mousePos.x > transform.position.x && !facingRight) { flip(); }
    }

    void applyMovement()
    {
        walk();
        jump();
    }

    void checkCollisions()
    {
        //onGround = Physics2D.Raycast(groundCheckLeft.transform.position, Vector2.down, groundCheckLength, groundLayer) || Physics2D.Raycast(groundCheckRight.transform.position, Vector2.down, groundCheckLength, groundLayer);
        onGround = Physics2D.OverlapCircle(groundCheckCircle.transform.position, groundCheckCircleRadius, groundLayer);
    }


    void walk()
    {
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput > 0 ? 5 : -5, rb.velocity.y);
        }
        else if( Mathf.Abs(rb.velocity.x) > 0.25)
        {
            rb.AddForce(new Vector2(rb.velocity.x > 0 ? -5 : 5, 0));
        } else if(Mathf.Abs(rb.velocity.x) < 0.26)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space)) {
            //rb.AddForce(new Vector2(0, jumpForce));
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 1;
            print("we're gouin to the moon johhny!!");
        }else if(!onGround && rb.velocity.y < 0)
        {
            rb.gravityScale = fallGrav;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0, 180, 0);
    }


    // Update is called once per frame
    void Update()
    {
        takeInput();
        checkCollisions();
        applyMovement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheckLeft.transform.position, groundCheckLeft.transform.position + Vector3.down * groundCheckLength);
        Gizmos.DrawLine(groundCheckRight.transform.position, groundCheckRight.transform.position + Vector3.down * groundCheckLength);
        Gizmos.DrawSphere(groundCheckCircle.transform.position, groundCheckCircleRadius);
    }
}
