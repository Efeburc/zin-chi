using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    GameObject player;
    public Animator Animator;
    public float initialVelocityx;
    public float initialVelocityy;
    float maxVelocityx;
    float maxVelocityy;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
        maxVelocityy = 10f;
        maxVelocityx = 10f;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<Movement>().isTouchingWalls = true;
            initialVelocityx = player.GetComponent<Movement>().transform.position.x;
            initialVelocityy = player.GetComponent<Movement>().transform.position.y;
            if (Mathf.Abs(initialVelocityy) > maxVelocityx)
            {
                initialVelocityx = maxVelocityx;
            }
            else if (Mathf.Abs(initialVelocityy) > maxVelocityy)
            {
                initialVelocityy = maxVelocityy;
            }

            //Animator.SetBool("grounded", true);
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<Movement>().isTouchingWalls = false;
            //Animator.SetBool("grounded", false);
            if (Input.GetButtonDown("Jump"))
            {
                player.GetComponent<Movement>().rb2d.velocity = Vector2.right * Mathf.Abs(initialVelocityx) * 2;
                player.GetComponent<Movement>().rb2d.velocity = Vector2.up * Mathf.Abs(initialVelocityy) * 2;
            }
            initialVelocityx = 0;

            initialVelocityy = 0;
        }

    }
}
