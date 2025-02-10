using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Power", menuName = "Power System/Powers/Defense")]
public class DefensePower : PowerObject
{
    
    void Awake()
    {
        type = PowerType.Defense;
    }

    
}
