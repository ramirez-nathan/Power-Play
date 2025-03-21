using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum PowerType
{
    Attack,
    Defense,
    Unique,
}*/
public abstract class PowerObject : ScriptableObject
{
    public Sprite uiDisplay;
    public string powerName;
    public int dmgIncrement = 4;
    public float dmgMult = 0.0f;
    public float defMult = 0.0f;
    public float speedMult = 0.0f;

    [TextArea(15, 20)] public string description;

    public abstract void EquipPower(GameObject player);
    public abstract void UnequipPower(GameObject player);

    public abstract void UpdateLogic(GameObject player);
}