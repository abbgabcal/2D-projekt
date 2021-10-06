using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float acceleration;
    public float jumpForce;
    public float maxVelocity;
    public float checkGroundRadius;
    public Transform isGroundChecker1;
    public Transform isGroundChecker2;  
    public LayerMask groundLayer;


    private bool isGrounded = false;
    private float startTime; 



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();

    }

    void Move()
    {
        if (isGrounded && System.Math.Abs(rb.velocity.x) < maxVelocity)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * acceleration;
            float v0 = rb.velocity.x;
            rb.velocity = new Vector2(moveBy + v0, rb.velocity.y);

        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            startTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            float dt = Time.time - startTime;
            startTime = 0;
            Debug.Log(dt);
            if (dt + jumpForce > 12)
            {
                rb.velocity = new Vector2(rb.velocity.x, 12);

            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce + dt);
            }
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider1 = Physics2D.OverlapCircle(isGroundChecker1.position, checkGroundRadius, groundLayer);
        Collider2D collider2 = Physics2D.OverlapCircle(isGroundChecker2.position, checkGroundRadius, groundLayer);


        if (collider1 != null || collider2 != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


}
