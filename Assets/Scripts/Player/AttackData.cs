using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    // Scriptible object for modular attack details and customization
    // Stores attack properties (damage, knockback, duration, etc.)

    public string attackName;
    public float damage;
    public float knockbackForce;
    // public Vector2 knockbackDirection;  // This is redundant since all we need is knockbackForce
    // public float hitboxDuration;       // Probably wont need this since we took care of it in unity animations
    public string animationName;
}
