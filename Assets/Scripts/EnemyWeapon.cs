using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{   
    public Vector3 attackOffset;
    public LayerMask attackMask;
    public PlayerHealth other;
    public int attackDamage = 20;
    public float attackRange = 1f;

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
