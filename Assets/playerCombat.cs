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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();

        }
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

}
