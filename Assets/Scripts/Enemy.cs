using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Animator animator;
    public GameObject coinPrefab;
    public Transform coinSpawnPoint;
    public Transform player;
    public Healthbar healthbar;
    public GameObject targetObject;
    public int maxHealth;
    public bool isFlipped = false;
    int currentHealth;

    public float hurtDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
       
        currentHealth -= damage;

        // Use a Coroutine to introduce a delay before playing the "Hurt" animation
        StartCoroutine(DelayedHurtAnimation());
        

        if(currentHealth <= 0) {
            turnOffHealthBar();
            Die();
        }
    }

    private IEnumerator DelayedHurtAnimation() {
        //Wait for the specified delay before playing the "Hurt" animation
        yield return new WaitForSeconds(hurtDelay);

        healthbar.SetHealth(currentHealth);
        //Play hurt animation
        animator.SetTrigger("Hurt");
    }
   
    void Die() {

        //Die animation
        animator.SetBool("IsDead", true);

        //Disable enemy collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        DropCoin();
    }

    void turnOffHealthBar() {
        targetObject.SetActive(false);
    }

    public void LookAtPlayer() {

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped) {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped) {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true; 
        }
    }

    public void DropCoin() {

        //Instantiate a coin at the specified spawn point
        GameObject coin = Instantiate(coinPrefab, coinSpawnPoint.position, Quaternion.identity);

        //Adding force to the coin for a more realistic drop
        Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();
        coinRigidbody.AddForce(new Vector2(0,10f), ForceMode2D.Impulse);

        //Destroy coin after a certain amount of time
        Destroy(coin, 5f);
    }
}
