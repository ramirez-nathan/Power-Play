using UnityEngine;
using UnityEngine.EventSystems;

public class PowerSelectionButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PowerObject power;            // The power this button represents
    public PowerSelectionPanel panel;    // Reference to your selection panel or manager
    public PowerDescriptionDisplay descriptionDisplay; 

    // This is called automatically by Unity when the user clicks on this UI element
    public void OnPointerClick(PointerEventData eventData)
    {
        // Check which mouse button was used
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Equip to Player 1
            panel.SelectPower(power, 0);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Equip to Player 2
            panel.SelectPower(power, 1);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionDisplay.ShowDescription(power.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionDisplay.ClearDescription();
    }
}



