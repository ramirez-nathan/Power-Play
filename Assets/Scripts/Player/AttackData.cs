using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    // Scriptible object for modular attack details and customization
    // Stores attack properties (damage, knockback, duration, etc.)

    public string attackName;
    public float damage;
    public float knockbackForce;
    public Vector2 knockbackDirection;
    public float hitboxDuration;
    public string animationName;
}
