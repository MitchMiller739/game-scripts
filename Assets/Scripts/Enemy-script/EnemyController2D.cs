using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    private Enemy enemy;
    public float aggroRange = 10.0f;
    public float moveSpeed = 3.0f;
    public bool facingRight = false;

    void Update() {
        
        //Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        //Makes sure that the enemy can only move if he isnt dead
        if (animator.GetBool("IsDead") == false) {
            if (distanceToPlayer <= aggroRange) {

                //Switch the animation status to run instead of idle
                animator.SetFloat("Speed", moveSpeed);

                //Calculate the direction only along the x-axis
                float xDirection = player.position.x - transform.position.x;

                //Move towards the player
                Vector2 movement = new Vector2(xDirection, 0).normalized;
                transform.Translate(movement * moveSpeed * Time.deltaTime);

                //Checks if the enemy is facing the player or not
                if (xDirection > 0 && !facingRight) {
                    Flip();
                }
                else if (xDirection < 0 && facingRight) {
                    Flip();
                }
            }
            else if (distanceToPlayer > aggroRange) {
                //Set the Speed float variable to 0 to go back to the idle animation 
                animator.SetFloat("Speed", 0);
            }  
        }
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
