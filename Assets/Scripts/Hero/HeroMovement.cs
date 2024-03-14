using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("GroundCheck")]
    [SerializeField] private GameObject GroundCheck;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private LayerMask GroundLayer;
    
    private bool isGrounded;
    private bool doubleJump;

    private Rigidbody2D rb;
    private float horizontal;

    private float vertical;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        IsGrounded();
        Move();
        Jump();
        FallDown();
    }
    private void Update()
    {
        DoubleJump();
        Flip();
    }
    private void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Jump()
    {
        if (isGrounded && vertical > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            doubleJump = true;
        }
    }
    private void DoubleJump()
    {
        if (doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
        }
    }
    private void FallDown()
    {
        if (!isGrounded && vertical < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce * 2);
        }
    }
    private void Flip()
    {
        if (horizontal > 0)
        {
            this.transform.localScale = Vector3.one;
        }else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, GroundCheckRadius,GroundLayer);
    }
}
