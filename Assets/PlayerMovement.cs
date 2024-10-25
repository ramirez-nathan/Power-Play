using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerStates;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    public Vector2 currentVelocity = Vector2.zero;

    [SerializeField]
    private int playerIndex = 0; // index to differentiate the 2 players

    public Rigidbody2D playerRigidBody;
    public GameObject stage;
    public PlayerState playerState;

    //private Vector2 inputVector = Vector2.zero;

    // Jump Logic
    public PlayerJumpState playerJumpState;
    public int jumpCount = 0;
    public int jumpFrameCounter = 0;
    public float xDirection;
    //public bool jumpStarted = false;
    public bool shortHop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
