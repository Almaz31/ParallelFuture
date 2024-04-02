using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    public bool flip;//#1
    private bool jumpRequest;
    public bool playingMobile = false;

    private Rigidbody2D rb;
    private float horizontal;

    private float vertical;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log(doubleJump);
        IsGrounded(); 

        if (jumpRequest) 
        {
            if (isGrounded || doubleJump) 
            {
                Jump(); 
            }
            jumpRequest = false; 
        }
        FallDown();
        Move(); 
    }
    void Update()
    {
        
        if (!playingMobile)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumpButtonPressed(); 
            }
        }

        Flip();
    }
    private void Move()
    {
        if (!playingMobile)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector2(horizontal * speed , rb.velocity.y); 
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        if (!isGrounded) 
        {
            doubleJump = false;
        }
        isGrounded = false; 
    }
   
    private void FallDown()
    {
        if (!isGrounded && vertical < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce * 2);
        }
    }
    public void Flip()
    {
        
        if (horizontal > 0)
        {
            this.transform.localScale = Vector3.one;
            flip = true;//right #2
            return;
        }else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
            flip = false;//left #3
            return;
        }
    }

    private void IsGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, GroundCheckRadius,GroundLayer);
        if (isGrounded && !wasGrounded) 
        {
            doubleJump = true; 
        }
    }

    public void OnJumpButtonPressed()
    {
        if (doubleJump)
            jumpRequest = true; 
          
        
    }
    #region MobileMove
    public void OnJumpTrue()
    {
        if (isGrounded)
        {
            jumpRequest = true; 
            
        }
        if (!isGrounded && doubleJump)
        {
            
            jumpRequest = true;
            doubleJump = true;
            
        }
    }
    public void OnJumpFalse()
    {
        doubleJump = false;
        jumpRequest = false;
    }

    private void MobileController(float direction)
    {
        horizontal = direction;
        Debug.Log(horizontal);
    }
    public void Left()
    {
        if (playingMobile)
        {
            MobileController(-1);
        }
               
    }
    public void Right()
    {
        if (playingMobile)
        {
            MobileController(1);
        }
    }
    public void Stop() 
    {
        if (playingMobile)
        {
            MobileController(0);
        }

    }
    #endregion

}
