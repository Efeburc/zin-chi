using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCleanUp : MonoBehaviour
{
    Rigidbody2D rb2d;

    public GameObject player;
    public float moveSpeed;
    public Animator Animator;
    public float jumpForce;
    public float walkSpeed;
    public float sprintSpeed;
    public bool isGrounded = false;
    int jumpcounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
