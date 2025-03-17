using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [Header("Attack Settings")]
    public AttackData currentAttack;
    public GameObject hitboxPrefab;
    public Transform hitboxSpawnPoint;
    public PlayerMain player;

    private bool isAttacking = false;

    //public void PerformAttack(AttackData attack)
    //{
    //    if (!isAttacking)
    //    {
    //        StartCoroutine(ExecuteAttack(attack));
    //    }
    //}

    //private IEnumerator ExecuteAttack(AttackData attack)
    //{
    //    isAttacking = true;
    //    currentAttack = attack;

    //    yield return new WaitForSeconds(0.1f); // Small delay for animation timing

    //    // Spawn hitbox
    //    GameObject hitbox = Instantiate(hitboxPrefab, hitboxSpawnPoint.position, Quaternion.identity);
    //    // AttackHitbox hitboxScript = hitbox.GetComponent<AttackHitbox>();

    //    //if (hitboxScript != null)
    //    //{
    //    //    hitboxScript.Initialize(attack.damage, attack.knockbackForce, attack.knockbackDirection);
    //    //}

    //    //yield return new WaitForSeconds(attack.hitboxDuration);

    //    Destroy(hitbox);
    //    isAttacking = false;
    //}

    //// ?? This function is called via Animation Event at the correct frame
    //public void ApplyAttackProperties()
    //{
    //    if (currentAttack == null)
    //    {
    //        Debug.LogWarning("No attack data assigned!");
    //        return;
    //    }

    // Pass attack properties to the hitbox
    // PlayerHitboxHandler.Initialize(currentAttack.damage, currentAttack.knockbackForce, currentAttack.knockbackDirection);
    //}

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
