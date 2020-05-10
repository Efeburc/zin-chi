using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject player;
    public float moveSpeed = 7;
    //private float jumpspeed = 100;//
    //private float fallspeed = 100;//
    public Animator animator;
    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string UP = "up";
    string buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            buttonPressed = RIGHT;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            buttonPressed = LEFT;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            buttonPressed = UP;
        }
        else
        {
            buttonPressed = null;
        }
 

    }
    private void FixedUpdate()
    {
        if(buttonPressed == RIGHT)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            animator.SetFloat("velocity", Mathf.Abs(moveSpeed));
            player.transform.localScale = new Vector3(1, 1, 1);

        }
        else if(buttonPressed == LEFT )
        {   
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            animator.SetFloat("velocity", Mathf.Abs(moveSpeed));
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(0,50f),ForceMode2D.Impulse);

        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            animator.SetFloat("velocity", 0);
        }

    }
   
}
