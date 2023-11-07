using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public Animator animator;
    public GameObject player;
    //public Rigidbody2D rb;
    public Healthbar healthbar;
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
       
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {

        //Die animation
        animator.SetBool("IsDead", true);
        StartCoroutine(StayDead());

        turnOffPlayerController();
    }

    IEnumerator StayDead() {
        yield return new WaitForSeconds(.87f);
        animator.SetBool("StayDead", true);
    }

    void turnOffPlayerController() {   
        gameObject.GetComponent<PlayerController>().enabled = false;
    }
}
