using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    public GameObject enemy;
    GameObject bruh;
    public Animator Animator;
    //max enemy health
    public int maxEnemyHealth = 100;
    //current health of the enemy
    public int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxEnemyHealth;
        Animator.SetFloat("hitpoints", 100f);
    }
    public void InflictDamage(int Damage)
    {
        CurrentHealth -= Damage;
        //getting hit and triggering the animation
        Animator.SetTrigger("hit");
        if(CurrentHealth <= 0)
        {
            Die();
            //ground check collision ını kapatıyorum yürürken yaşanan buglardan dolayı
            bruh = enemy.transform.Find("ground check").gameObject;
            bruh.GetComponent<Collider2D>().enabled = false;
            //my bullshit way to stop the body falling into the abbyss
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    public void Die()
    {
        //death animation here
        Animator.SetFloat("hitpoints" ,0f);
        //feedback
        Debug.Log("he ded lol");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //refresh health for debug purposes
        CurrentHealth = maxEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
