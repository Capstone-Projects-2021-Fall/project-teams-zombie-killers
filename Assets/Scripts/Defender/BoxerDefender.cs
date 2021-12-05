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

    public int attackDamage = 4;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, zombieLayers);
            if (hitEnemies.Length > 0)
            {
                Attack(hitEnemies);
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }

    }

    void Attack(Collider2D[] hitEnemies)
    {
        animator.SetTrigger("Attack");

        

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Zombie>().takeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
