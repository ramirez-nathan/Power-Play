using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class LoadoutUIController : MonoBehaviour
{
    [SerializeField] public PowerSelectionPanel panel;
    private PlayerInput playerInput; // Reference to player input
    int index = 0;
    void Awake()
    {
        panel = FindFirstObjectByType<PowerSelectionPanel>().GetComponent<PowerSelectionPanel>();
        playerInput = GetComponent<PlayerInput>();
        index = playerInput.playerIndex;
    }

    private void Start()
    {
        if (panel != null)
        {
            panel.ChangePlayerIndex(index);
        }
    }

    // Call this when a UI action occurs
    public void OnNavigate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            panel.ChangePlayerIndex(index);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            panel.ChangePlayerIndex(index);
        }
    }
}
