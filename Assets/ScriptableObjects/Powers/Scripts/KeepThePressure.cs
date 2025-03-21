using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power", menuName = "Power System/Power/KTP")]
public class KeepThePressure : PowerObject
{
    
    public int totalHits = 0;
    public override void EquipPower(GameObject player)
    {
        var main = player.GetComponent<PlayerMain>();
        //main.damage += 4;
    }

    public override void UnequipPower(GameObject player)
    {
        var main = player.GetComponent<PlayerMain>();
        //main.damage -= 4;
    }
    public override void UpdateLogic(GameObject player)
    {
        var main = player.GetComponent<PlayerMain>();
        var currState = main.playerStateMachine.currentState;
        
        
        if (currState.stateName == "Attacking")
        {
            if (currState.hitStreak > totalHits) 
            {
                //main.damage += ++dmgIncrement;
            }
        }
        if (currState.stateName == "Hurt")
        {
           //main.damage -= dmgIncrement;
            dmgIncrement = 0;
        }
        totalHits = currState.hitStreak;
    }
}
