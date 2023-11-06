using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{      
    public int speed = 15;
    public int currentPlayerHealth;
    public float attackRange = 3f;
    public PlayerHealth playerHealth;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        currentPlayerHealth = GameObject.Find("Samurai").GetComponent<PlayerHealth>().currentHealth;
        
        enemy.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange && currentPlayerHealth > 0) {
                animator.SetTrigger("Attack1");
                animator.SetBool("PlayerDead", false);
        }
        else if (currentPlayerHealth <= 0) {
            animator.SetBool("PlayerDead", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
    }


}
