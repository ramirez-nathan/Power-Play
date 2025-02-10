using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Deselect currently selected object
        EventSystem.current.SetSelectedGameObject(null);
    }
}