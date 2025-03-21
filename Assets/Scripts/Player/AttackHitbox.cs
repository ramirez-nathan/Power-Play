using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{   
    private float knockbackForce;
    public int finalDmg = 0;
    private Vector2 knockbackDirection;
    public HashSet<GameObject> hitEnemies = new HashSet<GameObject>(); // Prevents multiple hits

    public void Initialize(int damage, float attackKnockback, Vector2 direction)
    {
        finalDmg = damage;
        knockbackForce = attackKnockback;
        knockbackDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.otherCollider.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("AttackHitbox"))
        {
            
            if (collision.otherCollider.gameObject.layer == LayerMask.NameToLayer("PlayerHitbox"))
            {
                
                if (!hitEnemies.Contains(collision.gameObject))
                {
                    Debug.Log("attack read correctly");
                    hitEnemies.Add(collision.gameObject);

                    PlayerMain enemy = collision.gameObject.GetComponentInParent<PlayerMain>();
                    if (enemy != null)
                    {
                        Vector2 finalKnockback = knockbackDirection * knockbackForce;
                        enemy.TakeDamage(finalDmg, finalKnockback);
                    }
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.otherCollider.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("AttackHitbox"))
        {
            if (collision.otherCollider.gameObject.layer == LayerMask.NameToLayer("PlayerHitbox"))
            {
                
                if (!hitEnemies.Contains(collision.gameObject))
                {
                    Debug.Log("attack read correctly");
                    hitEnemies.Add(collision.gameObject);

                    PlayerMain enemy = collision.gameObject.GetComponentInParent<PlayerMain>();
                    if (enemy != null)
                    {
                        Vector2 finalKnockback = knockbackDirection * knockbackForce;
                        enemy.TakeDamage(finalDmg, finalKnockback);
                    }
                }
            }
        }
    }
}
