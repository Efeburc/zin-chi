using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    GameObject player;
    public Animator Animator;
    public float initialVelocityx;
    public float initialVelocityy;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
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
            initialVelocityx = player.GetComponent<Movement>().rb2d.velocity.x;
            initialVelocityy = player.GetComponent<Movement>().rb2d.velocity.y;
            //Animator.SetBool("grounded", true);
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<Movement>().isTouchingWalls = false;
            //Animator.SetBool("grounded", false);
            player.GetComponent<Movement>().rb2d.velocity = initialVelocity.y;
        }

    }
}
