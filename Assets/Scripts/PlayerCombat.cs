using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{   

    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.05f;
    public int attackDamage1 = 20;
    public int attackDamage2 = 35;
    public float attackRate1 = 1f;
    public float attackRate2 = 2f;
    float nextAttackTime1 = 0f;
    float nextAttackTime2 = 0f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime1) {
            if (Input.GetKeyDown("o")) {
                Attack1();
                nextAttackTime1 = Time.time + 1f / attackRate1;
            } 
        }
        if(Time.time >= nextAttackTime2) {
            if (Input.GetKeyDown("p")) {
                Attack2();
                nextAttackTime2 = Time.time + 3f / attackRate2;
            } 
        }
    }

    void Attack1() {
        //Play an attack animation
        animator.SetTrigger("Attack1");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage1);
        }
    }
    
    void Attack2() {
        
        //Play attack2 animation
        animator.SetTrigger("Attack2");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage the enemy
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage2);
        }
    }
    
    void OnDrawGizmosSelected() {
        
        if(attackPoint == null) {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}







