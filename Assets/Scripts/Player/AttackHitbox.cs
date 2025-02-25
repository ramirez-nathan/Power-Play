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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!hitEnemies.Contains(collision.gameObject))
            {
                hitEnemies.Add(collision.gameObject);

                //EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
                //if (enemy != null)
                //{
                //    Vector2 finalKnockback = knockbackDirection * knockbackForce;
                //    enemy.TakeDamage(damage, finalKnockback);
                //}
            }
        }
    }

    private void OnEnable()
    {
        hitEnemies.Clear(); // Reset for the next attack
    }
}
