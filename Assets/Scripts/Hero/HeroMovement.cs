using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private GameObject GroundCheck;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private LayerMask GroundLayer;


    [SerializeField] private bool isGrounded;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        dir=new Vector2(horizontal, 0).normalized;

        rb.velocity = dir*speed;

        if (isGrounded) {
            rb.AddForce(new Vector2(0, vertical * jumpForce));
            isGrounded = false; 
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (1.5f) * Time.deltaTime;
        }

    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, GroundCheckRadius,GroundLayer);
    }
}
