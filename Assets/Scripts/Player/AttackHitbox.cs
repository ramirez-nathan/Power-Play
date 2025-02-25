using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    // Detects collisions & applies damage
    [Header("Attack Settings")]
    public int damage = 10;
    public float knockbackForce = 5f;
    public Vector2 knockbackDirection = Vector2.right;
    public LayerMask enemyLayer; // Only detect enemies
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>(); // Prevents multiple hits per frame

    public void Initialize(int attackDamage, float attackKnockback, Vector2 direction)
    {
        damage = attackDamage;
        knockbackForce = attackKnockback;
        knockbackDirection = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0) // LayerMask filtering
        {
            if (!hitEnemies.Contains(collision.gameObject)) // Prevent multiple hits
            {
                hitEnemies.Add(collision.gameObject);

                //EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
                //if (enemy != null)
                //{
                //    enemy.TakeDamage(damage, knockbackDirection * knockbackForce);
                //}
            }
        }
    }

    private void OnEnable()
    {
        hitEnemies.Clear(); // Reset hit list when hitbox is reactivated
    }
}
