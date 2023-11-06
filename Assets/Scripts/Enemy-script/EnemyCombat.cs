using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int currentPlayerHealth;
    public float attackRange = 3f;
    public Animator animator;
    public PlayerHealth playerHealth;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
