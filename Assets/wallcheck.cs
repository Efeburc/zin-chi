using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    GameObject player;
    public Animator Animator;
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

            //Animator.SetBool("grounded", true);
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Walls")
        {
            player.GetComponent<Movement>().isTouchingWalls = false;
            //Animator.SetBool("grounded", false);
        }

    }
}
