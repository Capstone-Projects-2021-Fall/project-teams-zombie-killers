using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerDefender : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask zombieLayers;

    public float attackRange = 0.5f;
    
    public float attackRate = 1f;
    float nextAttackTime = 0f;



    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, zombieLayers);

        foreach(Collider2D enemy in hitEnemies)
            {
            Debug.Log("Attack");
            
            enemy.GetComponent<Zombie>().takeDamage(4);
            enemy.GetComponent<Zombie>().ResetMaterial();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
