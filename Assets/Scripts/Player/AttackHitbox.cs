using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private float damage;
    private float knockbackForce;
    private Vector2 knockbackDirection;
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>(); // Prevents multiple hits

    public void Initialize(float attackDamage, float attackKnockback, Vector2 direction)
    {
        damage = attackDamage;
        knockbackForce = attackKnockback;
        knockbackDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!hitEnemies.Contains(collision.gameObject))
            {
                hitEnemies.Add(collision.gameObject);

                PlayerMain enemy = collision.gameObject.GetComponent<PlayerMain>();
                if (enemy != null)
                {
                    Vector2 finalKnockback = knockbackDirection * knockbackForce;
                    enemy.TakeDamage(damage, finalKnockback);
                }
            }
        }
    }

    private void OnEnable()
    {
        hitEnemies.Clear(); // Reset for the next attack
    }
}
