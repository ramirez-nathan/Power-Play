using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Power", menuName = "Power System/Power/PHX")]
public class PheonixStrike : PowerObject
{
    private int lastOtherPlayerStocks = -1;
    public override void EquipPower(GameObject player)
    {

    }

    public override void UnequipPower(GameObject player)
    {

    }
    public override void UpdateLogic(GameObject player)
    {
        // Only perform logic if we're in the "Game" scene
        if (SceneManager.GetActiveScene().name != "Game")
            return;

        // Find all objects tagged "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject otherPlayer = null;

        // Find the player object that is not the one this power is attached to.
        foreach (GameObject p in players)
        {
            if (p != player)
            {
                otherPlayer = p;
                break;
            }
        }

        if (otherPlayer == null)
            return;

        // Get the PlayerMain component from the other player
        PlayerMain otherPlayerMain = otherPlayer.GetComponent<PlayerMain>();
        if (otherPlayerMain == null)
            return;

        // If this is our first update, record the current stocks and do nothing else.
        if (lastOtherPlayerStocks == -1)
        {
            lastOtherPlayerStocks = otherPlayerMain.numStocks;
            return;
        }

        // Check if the other player's stocks have decreased since the last frame.
        if (otherPlayerMain.numStocks < lastOtherPlayerStocks)
        {
            // Get the PlayerMain component for the current player to heal it
            PlayerMain playerMain = player.GetComponent<PlayerMain>();
            if (playerMain != null)
            {
                // Calculate 25% of the player's max health and round it to an integer.
                int healAmount = Mathf.RoundToInt(playerMain.maxHealth * 0.25f);
                // Add healing but do not exceed maxHealth
                playerMain.currentHealth = Mathf.Min(playerMain.currentHealth + healAmount, playerMain.maxHealth);
                Debug.Log($"Healed {player.name} by {healAmount}. New health: {playerMain.currentHealth}");
            }
        }

        // Update the stored stocks value for next frame.
        lastOtherPlayerStocks = otherPlayerMain.numStocks;
    }
    
}