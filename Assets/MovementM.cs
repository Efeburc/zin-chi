using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementM : MonoBehaviour
{
    public GameObject player;
    public float xspeed = 5f, jumpForce = 5f;
    public Animator ani;
    public bool isGrounded = false;

    private bool mjump;

    Rigidbody2D rb2d;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {     
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        scaler();
        if (Input.GetAxis("Horizontal") != 0)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f);
            transform.position += movement * Time.deltaTime * xspeed;
            ani.SetFloat("velocity", Mathf.Abs(xspeed));
        }
        else
        {
            ani.SetFloat("velocity", 0);
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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
}
