using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private bool facingRight = true;
    private float moveHorizontal;
    private float moveVertical;
    private float jumpTime = 0f;
    private float jumpRate = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        moveSpeed = 4.25f;
        jumpForce = 75f;
        isJumping = false;


    }

    // Update is called once per frame
    void Update()
    {   
        //Gathers the users input for A or D for running and W for jumping
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //Detects movements to the left or the right and then plays the run animation
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if (isJumping == true) {
            animator.SetBool("IsJumping", true);
        }
        else if (isJumping == false) {
            animator.SetBool("IsJumping", false);
        }
    }

    void FixedUpdate() 
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f) 
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if(!isJumping && moveVertical > 0.1f) 
        {
            if(Time.time >= jumpTime) {
                if (moveVertical > 0.01f) {
                    rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
                    jumpTime = Time.time + 2f / jumpRate;
                } 
            }      
        }
        
        if(moveHorizontal > 0 && !facingRight) {
            Flip();
        } 
        
        if(moveHorizontal < 0 && facingRight) {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform") {
            isJumping = false;
           
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform") {
            isJumping = true; 
        }
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}


