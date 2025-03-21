using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerSelectionPanel : MonoBehaviour
{
    public LoadoutObject player1Loadout;
    public LoadoutObject player2Loadout;

    public List<Button> player1LoadoutButtons; // List of UI buttons for Player 1
    public List<Button> player2LoadoutButtons; // List of UI buttons for Player 2


    public Transform powerButtonContainer; // Panel that holds power buttons
    public GameObject powerButtonPrefab; // Prefab for UI buttons
    [SerializeField] public int playerIndex = 0;

    public List<PowerObject> availablePowers; // List of all selectable powers

    public void ChangePlayerIndex(int index)
    {
        // If it's already the same, no need to do anything
        if (playerIndex == index)
        {
            return;
        }
        // Otherwise, update the index and log
        playerIndex = index;
        Debug.Log($"Power selection panel updated for Player {index}");
    }

    public void SelectPower(PowerObject power, int playerIndex)
    {
        if (playerIndex == 0)
        {
            if (player1Loadout.AddPower(power))
            {
                Debug.Log($"Equipped {power.powerName} to Player 1");
            }
            else
            {
                player1Loadout.RemovePower(power);
            }
            UpdateLoadoutUI(player1Loadout, player1LoadoutButtons);
        }
        else if (playerIndex == 1)
        {
            if (player2Loadout.AddPower(power))
            {
                Debug.Log($"Equipped {power.powerName} to Player 2");
            }
            else
            {
                player2Loadout.RemovePower(power);
            }
            UpdateLoadoutUI(player2Loadout, player2LoadoutButtons);
        }
    }

    void UpdateLoadoutUI(LoadoutObject loadout, List<Button> buttons)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            TextMeshProUGUI buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            if (i < loadout.Container.Count)
            {
                buttonText.text = loadout.Container[i].powerName;
            }
            else
            {
                buttonText.text = "";
            }
        }
    }

    public void ConfirmLoadoutSelection(int playerIndex) // final loadout confirmation
    { 
        if (playerIndex == 0)
        {
            GameManager.Instance.player1Loadout = player1Loadout;
        }
        
        else if (playerIndex == 1)
        {
            GameManager.Instance.player2Loadout = player2Loadout;
        }
        
    }

    void UpdateUI()
    {
        // TODO: Add UI updates (e.g., highlight selected powers, disable full loadout)
    }
}
