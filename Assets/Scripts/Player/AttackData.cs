using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    // Scriptible object for modular attack details and customization
    // Stores attack properties (damage and knockback)

    public string attackName;
    public float damage;
    public float knockbackForce;
    // public string animationName;  // Probably dont need this also
}
