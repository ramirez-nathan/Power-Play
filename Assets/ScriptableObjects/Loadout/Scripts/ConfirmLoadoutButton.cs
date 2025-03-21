using UnityEngine.EventSystems;
using UnityEngine;

public class ConfirmLoadoutButton : MonoBehaviour, IPointerClickHandler
{
    public PowerSelectionPanel panel;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check which mouse button was used
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Equip to Player 1
            panel.ConfirmLoadoutSelection(0);
            Debug.Log("Confirmed loadout for Player 1");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Equip to Player 2
            panel.ConfirmLoadoutSelection(1);
            Debug.Log("Confirmed loadout for Player 2");
        }
    }
}