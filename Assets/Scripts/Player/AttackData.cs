using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    public string attackName;
    public int damage;
    public float knockbackForce;
    public Vector2 knockbackDirection;
    public float hitboxDuration;
    public string animationName;
}
