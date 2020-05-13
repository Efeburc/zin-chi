using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*
 * REVISION LOG
 * 16:38(Turkey) - 12 May 2020
 * Cleaned the previous Movement script with the exception of dashing mechanism
*/

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector3 movement;
    public GameObject player;
    public float walkSpeed = 10f, sprintSpeed = 16f, jumpForce = 5f;
    public Animator Animator;

    //Dash variables
    public float DashSpeed;
    private float DashTime;
    public float StartDashTime;
    public bool isDashing;
    //private string direction;
    //Dash variables

    //Jump variables
    private byte jumpCounter;
    public bool isGrounded = false;
    public bool isTouchingWalls;
    public float wJumpCounter;
    public float jumpTimer;
    public float StartjumpTimer;
    public bool StartJTimer;
    public bool Jumping;
    //Jump variables

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpCounter = 1;
        wJumpCounter = 1;
    }
    // Update is called once per frame
    void Update()
    {
        jump();
        if (StartJTimer == true)
        {
            jumpTimer -= Time.deltaTime;
        }
        JumpFall();
        sprint();
        scaler();
        dash();
        if (Input.GetAxis("Horizontal") != 0)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f);
            transform.position += movement * Time.deltaTime * walkSpeed;
            Animator.SetFloat("velocity", Mathf.Abs(walkSpeed));
        }
        else
        {
            //Start idle animation on 0 horizontal speed
            Animator.SetFloat("velocity", 0);
        }
        if((isTouchingWalls == true && isGrounded == false)&& (Input.GetButtonDown("Jump") && wJumpCounter == 1))
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                rb2d.velocity = new Vector2(20, 20);
                wJumpCounter--;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                rb2d.velocity = new Vector2(-20, 20);
                wJumpCounter--;
            }
        }
    }
    private void scaler()
    {
        //turning the sprite
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
    private void sprint()
    {
        //Sprinting
        if (Input.GetKey(KeyCode.E))
        {
            walkSpeed = sprintSpeed;
        }
        else
        {
            walkSpeed = 10f;
        }
    }
    private void jump()
    {
        if (isGrounded == true)
        {
            jumpCounter = 1;
            wJumpCounter = 1;
            jumpTimer = StartjumpTimer;
            StartJTimer = false;

        }
        if (Input.GetButtonDown("Jump") && jumpCounter > 0)
        {

            //rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); iki methodun arasında kaldım
            rb2d.velocity = new Vector2(0f, jumpForce);
            jumpTimer = StartjumpTimer;
            jumpCounter--;

        }
        if(isGrounded == false && jumpTimer >= 0)
        {
            StartJTimer = true;
            rb2d.gravityScale = 0;
        }
    }
        private void JumpFall()
        {
        if (jumpTimer <= 0)
        {
            rb2d.gravityScale = 5;
            StartJTimer = false;
        }
        }
    private void dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                rb2d.velocity = Vector2.left * DashSpeed;
                rb2d.gravityScale = 0;
                //rb2d.AddForce(new Vector2(-DashSpeed, 0f), ForceMode2D.Impulse);
                isDashing = true;
                //Animator.SetBool("isDashing", true);
                DashTime = StartDashTime;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                rb2d.velocity = Vector2.right * DashSpeed;
                rb2d.gravityScale = 0;
                //rb2d.AddForce(new Vector2(DashSpeed, 0f), ForceMode2D.Impulse);
                isDashing = true;
                //Animator.SetBool("isDashing", true);
                DashTime = StartDashTime;
            }else
                isDashing = false;
        }
        DashTime -= Time.deltaTime;
        if (DashTime <= 0 && isDashing == true)
        {
            rb2d.velocity = Vector2.zero;
            isDashing = false;
            //Animator.SetBool("isDashing", false);  
            rb2d.gravityScale = 1;
        }
    }
}