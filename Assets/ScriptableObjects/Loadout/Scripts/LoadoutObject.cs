using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Loadout", menuName = "Loadout System/Loadout")]
public class LoadoutObject : ScriptableObject
{
   public List<PowerObject> Container = new List<PowerObject>();
   
}

[System.Serializable]
public class LoadoutSlot
{
    public PowerObject power;
    public bool isEquippable = true;
    public LoadoutSlot(PowerObject power)
    {
        this.power = power;
    }
    public void EquipPower()
    {
        isEquippable = false;
    }
    public void UnequipPower()
    {
        isEquippable = true;
    }
}
