using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    public struct PlayerActions
    {
        public InputAction move; // joystick/WASD
        public InputAction jump; // Space/South Button
        public InputAction neutralLight; // neutral ground/air J/West button
        public InputAction forwardLight; // moving ground/air J/West button
        public InputAction downLight; // down ground/air J/West button
        public InputAction neutralUpHeavy; // neutral/up ground/air L/East button
        public InputAction forwardHeavy; // forward ground/air I/L/North/East button
        public InputAction downHeavy; // down ground/air I/L/North/East button 
        public InputAction neutralUpRanged; // neutral/up ground/air L/East button 
        public InputAction forwardRanged; // forward ground/air L/East button 
        public InputAction downRanged; // down ground/air L/East button 
    } public PlayerActions playerControls;

    private PlayerMain playerMain;
    private PlayerInput playerInput; 
    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        
        // Finds all objects with playermovement component attached
        var playerMains = FindObjectsOfType<PlayerMain>();

        // retrieves player index 
        var index = playerInput.playerIndex;

        // Finds the PlayerMovement with the matching player index to associate it with this player
        playerMain = playerMains.FirstOrDefault(m => m.GetPlayerIndex() == index);
        playerMain.Initialize(this); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnEnable()
    {
        // Subscribe to input actions
        playerControls.move = playerInput.actions["Move"];
        playerControls.jump = playerInput.actions["Jump"];
        playerControls.neutralLight = playerInput.actions["NeutralLight"];
        playerControls.forwardLight = playerInput.actions["ForwardLight"];
        playerControls.downLight = playerInput.actions["DownLight"];
        playerControls.neutralUpHeavy = playerInput.actions["NeutralUpHeavy"];
        playerControls.forwardHeavy = playerInput.actions["ForwardHeavy"];
        playerControls.downHeavy = playerInput.actions["DownHeavy"];
        playerControls.neutralUpRanged = playerInput.actions["NeutralUpRanged"];
        playerControls.forwardRanged = playerInput.actions["ForwardRanged"];
        playerControls.downRanged = playerInput.actions["DownRanged"];



        playerControls.move.started += playerMain.Move;
        playerControls.move.canceled += playerMain.Move;

        playerControls.jump.started += playerMain.Jump;  // Track the jump press
        playerControls.jump.canceled += playerMain.Jump; // Track the jump release

        playerControls.neutralLight.started += playerMain.NeutralLight;
        playerControls.forwardLight.started += playerMain.ForwardLight;
        playerControls.downLight.started += playerMain.DownLight;
        playerControls.neutralUpHeavy.started += playerMain.NeutralUpHeavy;
        playerControls.forwardHeavy.started += playerMain.ForwardHeavy;
        playerControls.downHeavy.started += playerMain.DownHeavy;
        playerControls.forwardRanged.started += playerMain.ForwardRanged;
        playerControls.neutralUpRanged.started += playerMain.NeutralUpRanged;
        playerControls.downRanged.started += playerMain.DownRanged;
    }
    // Unsubscribe all methods to avoid memory leaks
    private void OnDisable()
    {
        playerControls.move.started -= playerMain.Move;
        playerControls.move.canceled -= playerMain.Move;

        playerControls.jump.started -= playerMain.Jump;
        playerControls.jump.canceled -= playerMain.Jump;

        playerControls.neutralLight.started -= playerMain.NeutralLight;
        playerControls.forwardLight.started -= playerMain.ForwardLight;
        playerControls.downLight.started -= playerMain.DownLight;
        playerControls.neutralUpHeavy.started -= playerMain.NeutralUpHeavy;
        playerControls.forwardHeavy.started -= playerMain.ForwardHeavy;
        playerControls.downHeavy.started -= playerMain.DownHeavy;
        playerControls.forwardRanged.started -= playerMain.ForwardRanged;
        playerControls.neutralUpRanged.started -= playerMain.NeutralUpRanged;
        playerControls.downRanged.started -= playerMain.DownRanged;
    }

}
