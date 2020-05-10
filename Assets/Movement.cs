using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject player;
    public float moveSpeed = 5f;
    public Animator Animator;
    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string UP = "up";
    string buttonPressed;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         if (Input.GetButtonDown("Jump"))
            {
                jump();
            }
        if (Input.GetKey(KeyCode.D))
            {
                buttonPressed = RIGHT;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                buttonPressed = LEFT;
            }
            else
            {
                buttonPressed = null;
            }

        }
        // Update is called once per frame
        void FixedUpdate()
        {
        scaler();
            if (buttonPressed == RIGHT || buttonPressed == LEFT)
            {
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                transform.position += movement * Time.deltaTime * moveSpeed;
                Animator.SetFloat("velocity", Mathf.Abs(moveSpeed));
        }
        else if(buttonPressed == null)
        {
            Animator.SetFloat("velocity", 0);
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
        private void jump(){
        
            if(Input.GetButtonDown("Jump") && isGrounded == true){

             rb2d.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);

            }
        }
    }
 