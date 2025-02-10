using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    Attack,
    Defense,
    Unique,
}
public abstract class PowerObject : ScriptableObject
{
    public Sprite uiDisplay;
    public PowerType type;
    public string powerName;
    [TextArea(15, 20)] public string description;

    public abstract void EquipPower(GameObject player);
    public abstract void UnequipPower(GameObject player);
}