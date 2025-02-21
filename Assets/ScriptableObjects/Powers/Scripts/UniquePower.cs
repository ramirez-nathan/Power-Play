using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Power", menuName = "Power System/Powers/Unique")]
public class UniquePower : PowerObject
{
    
    void Awake()
    {
        type = PowerType.Unique;
    }

    public override void EquipPower(GameObject player)
    {

    }

    public override void UnequipPower(GameObject player)
    {

    }
    public override void UpdateLogic(GameObject player)
    {

    }
}
