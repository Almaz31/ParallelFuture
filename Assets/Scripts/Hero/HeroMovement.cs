using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool flip;//#1
    private bool jumpRequest;
    [SerializeField] private bool playingMobile = false;

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
        IsGrounded(); // Zemin kontrol� her fizik g�ncellemesinde yap�l�r

        if (jumpRequest) // Z�plama iste�i varsa
        {
            if (isGrounded || doubleJump) // E�er zemindeyse veya �ift z�plama hakk� varsa
            {
                Jump(); // Z�pla
            }
            jumpRequest = false; // Z�plama iste�ini s�f�rla
        }
        FallDown();
        Move(); // Hareket et
    }
    void Update()
    {
        // Klavye kontrol� veya di�er frame tabanl� g�ncellemeler
        if (!playingMobile)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumpButtonPressed(); // Klavyeden z�plama komutu
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Z�plama kuvvetini uygula
        if (!isGrounded) // E�er zeminde de�ilse, �ift z�plama hakk�n� kullan
        {
            doubleJump = false;
        }
        isGrounded = false; // Zemin kontrol� FixedUpdate i�inde g�ncellenecek
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
        if (isGrounded && !wasGrounded) // E�er karakter yeniden zemine temas ettiyse
        {
            doubleJump = true; // �ift z�plama hakk�n� yenile
        }
    }

    public void OnJumpButtonPressed()
    {
        
      jumpRequest = true; // Z�plama iste�ini ayarla
          
        
    }



    #region MobileMove


    public void OnJumpTrue()
    {
        if (isGrounded)
        {
            jumpRequest = true; // Z�plama iste�ini ayarla
            
        }
        else if (!isGrounded && doubleJump)
        {
            // �kinci z�plama (�ift z�plama) i�in ek kontrol
            jumpRequest = true;
            doubleJump = false;
            
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
