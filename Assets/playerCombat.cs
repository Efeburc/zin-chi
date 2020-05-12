using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator Animator;
    public Transform attackPoint; //Defining the attack hitbox
    public float attackRange = 0.5f; //attack range duh
    public LayerMask enemylayers;
    public int attackDamage = 10;


    // Combo variables
    public float ComboTime; // Combo Time Delta
    public bool isCombo; // Combo Bool
    // Update is called once per frame
    void Start()
    {
    }
    void Update()
    {   
        ComboAttack();
        if (ComboTime < 0)
        {
            ComboTime = 0;
        }
        else ComboTime -= Time.deltaTime;
    }
    void Attack()
    {
      ///attack animation
     Animator.SetTrigger("attack");
        ///hitbox
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemylayers);
        
      ///damage
      foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemybehavior>().InflictDamage(attackDamage);

        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        //hitbox gösterme
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    void ComboAttack()
    {
        if (Input.GetButtonDown("Fire1") && ComboTime <= 0.40f)
        {

            ComboTime = 1f;
            isCombo = true;
            Attack();
            Debug.Log("Attack");
        }
        else if (Input.GetButtonDown("Fire1") && (ComboTime >= 0.40f && ComboTime <= 1.00f))
        {
            isCombo = true;
            ComboTime += 1f;
            Attack();
            Debug.Log("Second Attack");
        }
        else if (Input.GetButtonDown("Fire1") && ComboTime >= 1.00f)
        {
            isCombo = true;
            Attack();
            Debug.Log("Third Attack");
            ComboTime = 0f;
        }
        else if (ComboTime <= 0 && isCombo == true)
        {
            isCombo = false;
            //Animator.SetBool("isCombo", false);
        }
    }
}