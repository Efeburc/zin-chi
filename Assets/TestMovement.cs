using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Animator Animator;
    Rigidbody2D player;
    public float movementSpeed = 10f;
    public bool isGrounded = false;
    public float jumpForce = 4f;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Jump")) jumping();
    }
    void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.D)){
            scaler();
            running();
        }
        else if(Input.GetKey(KeyCode.A)){
            scaler();
            running();
        }
        else{
            Animator.SetFloat("velocity",0);
        }
    }

    private void running(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;
        Animator.SetFloat("velocity", Mathf.Abs(movementSpeed));
        }

    private void scaler(){
        Vector3 characterScale = transform.localScale;

        if(Input.GetAxis("Horizontal") > 0) characterScale.x = 1;
        else if(Input.GetAxis("Horizontal") < 0) characterScale.x = -1;

        transform.localScale = characterScale;
    }

    private void jumping(){
        if(Input.GetKey(KeyCode.Space) && isGrounded)
            player.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse); 
    }
}
