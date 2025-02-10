using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Power", menuName = "Power System/Powers/Attack")]
public class AttackPower : PowerObject
{
    
    void Awake()
    {
        type = PowerType.Attack;
    }

    
}
