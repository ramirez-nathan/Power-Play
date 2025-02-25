using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [Header("Attack Settings")]
    public AttackData currentAttack;
    public GameObject hitboxPrefab;
    public Transform hitboxSpawnPoint;

    private bool isAttacking = false;

    public void PerformAttack(AttackData attack)
    {
        if (!isAttacking)
        {
            StartCoroutine(ExecuteAttack(attack));
        }
    }

    private IEnumerator ExecuteAttack(AttackData attack)
    {
        isAttacking = true;
        currentAttack = attack;

        yield return new WaitForSeconds(0.1f); // Small delay for animation timing

        // Spawn hitbox
        GameObject hitbox = Instantiate(hitboxPrefab, hitboxSpawnPoint.position, Quaternion.identity);
        // AttackHitbox hitboxScript = hitbox.GetComponent<AttackHitbox>();

        //if (hitboxScript != null)
        //{
        //    hitboxScript.Initialize(attack.damage, attack.knockbackForce, attack.knockbackDirection);
        //}

        yield return new WaitForSeconds(attack.hitboxDuration);

        Destroy(hitbox);
        isAttacking = false;
    }
}
