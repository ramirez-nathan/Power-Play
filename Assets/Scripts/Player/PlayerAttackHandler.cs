using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [Header("Attack Settings")]
    public AttackData currentAttack;               // Stores the current active attack
    public CapsuleCollider2D hitboxCollider;       // Reference to our current attack hitbox
    public Transform hitboxSpawnPoint;
    public PlayerMain player;                      // Reference to our player

    private bool isAttacking = false;

    // What should a player have? when an input gets called, an animation plays, a hitbox gets activated, and attack logic gets applied (damage and knockback)
    // This file should deal with the attack logic
    // So what do we need for attack logic?
    // We should pass in the current attack (which is a scriptable object) giving us their damage and knockback values

    public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
    {
        if (!player.isAlive) return; // Prevent multiple deaths

        // Reduce health
        player.currentHealth -= damage;

        // Apply knockback
        Knockback(knockbackDirection, knockbackForce);

        // If health reaches 0, handle death
        if (player.currentHealth <= 0)
        {
            // HandleDeath();   // This should be a call to kill player,we should already have this somewhere
        }
    }

    private void Knockback(Vector2 direction, float force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Reset previous movement
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }


}
