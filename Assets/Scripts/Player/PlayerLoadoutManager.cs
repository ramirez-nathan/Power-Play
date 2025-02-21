using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLoadoutManager : MonoBehaviour
{ // this is used in Game Scene, attached to player object 
    public int playerIndex; // 1 or 2
    private LoadoutObject equippedLoadout;
    private GameObject player;

    void Start()
    {
        player = gameObject;
        equippedLoadout = (playerIndex == 1) ? GameManager.Instance.player1Loadout : GameManager.Instance.player2Loadout;
        ApplyLoadout();
    }

    void ApplyLoadout()
    {
        if (equippedLoadout == null) return;
        foreach (var power in equippedLoadout.Container)
        {
            power.EquipPower(player);
        }
    }

    private void LateUpdate()
    { // this is for all the active power abilities
        foreach (var power in equippedLoadout.Container)
        {
            power.UpdateLogic(player); 
        }
    }
}
