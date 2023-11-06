using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int currentPlayerHealth;
    public float attackRange = 3f;
    public int attackDamage = 20;
    public Animator animator;
    public LayerMask attackMask;
    public PlayerHealth playerHealth;
    public Vector3 attackOffset;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly update the Players health so the enemy will know when to stop attacking
        currentPlayerHealth = GameObject.Find("Samurai").GetComponent<PlayerHealth>().currentHealth;

        if (Vector2.Distance(player.position, rb.position) <= attackRange && currentPlayerHealth > 0) {
            animator.SetTrigger("Attack1");
            animator.SetBool("PlayerDead", false);
        }
        else if (currentPlayerHealth <= 0) {
            animator.SetBool("PlayerDead", true);
        }
    }
    void Exit() {
        animator.ResetTrigger("Attack1");
    }

    public void Attack1() {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null) {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }   
    }
}
