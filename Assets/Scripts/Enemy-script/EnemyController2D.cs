using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    private Enemy enemy;
    public Transform player;
    public PlayerHealth playerHealth;
    public Animator animator;
    private int currentPlayerHealth;
    private bool facingRight = false;
    public float aggroRange = 10.0f;
    public float moveSpeed = 3.0f;

    void Update() {
        
        //Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Constantly update the Players health so the enemy will know when to stop moving
        currentPlayerHealth = GameObject.Find("Samurai").GetComponent<PlayerHealth>().currentHealth;
        
        //Makes sure that the enemy can only move if he isnt dead
        if (animator.GetBool("IsDead") == false && currentPlayerHealth > 0) {
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
        else if (currentPlayerHealth <= 0) {
            //If the player is dead set the enemy to stop moving
            animator.SetFloat("Speed", 0);
        }
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
