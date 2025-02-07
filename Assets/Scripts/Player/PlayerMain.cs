using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMain : MonoBehaviour
{
    [SerializeField]
    public Transform spawnPoint;
    public int maxHealth = 100;
    public int currentHealth = 100;
    public float moveSpeed = 10f;
    public int numStocks = 3;
    public Vector2 currentVelocity = Vector2.zero;
    public GameOverScreen gameOverScreen; // The game over screen
    public AudioSource deathSound;       // A sound that gets played when the character gets destroyed
    private bool controllerConnected = false;
    

    [SerializeField]
    private int playerIndex = 0; // index to differentiate the 2 players
    public enum PlayerState
    {
        Idle,
        Grounded,
        Airborne,
        Dead
    }
    public PlayerState playerState;
    public enum PlayerJumpState
    {
        JumpHeld,
        JumpReleased
    }
    public PlayerJumpState playerJumpState;

    public Rigidbody2D playerRigidBody;
    // public GameObject stage; // no longer needed

    public PlayerInputHandler playerInputHandler;
    public PlayerStateMachine playerStateMachine;
    public Animator animator;            // Controls all the animations of the player.
    private bool isOnFloor = true;       // Tracks if the player is on the stage (grounded).
    public bool isFacingRight = true;    // Tracks whether the player's sprite is facing right
    public bool fellOffMap = false;
    public bool isVulnerable = true;
    public bool isAlive = true;


    // ------------------- Attack Constants ---------------------- //
    public bool isAttacking = false;
    public float knockbackValue = 0.0f;
    public enum PlayerAttackType
    {
        NeutralLight,
        ForwardLight,
        DownLight,
        NeutralUpHeavy,
        ForwardHeavy,
        DownHeavy,
        NeutralUpRanged,
        ForwardRanged,
        DownRanged
    } public PlayerAttackType playerAttackType;
    // ------------------- Attack Constants ---------------------- //
    public Vector2 moveInput { get; private set; }
    public bool holdingMove = false;

    // Jump Logic
    public int jumpCount = 0;
    public int jumpFrameCounter = 0;
    public bool finishedJump = false;
    public bool shortHop = false;

    // Out of bounds range, x = +- 11, y = -7
    private float outOfBoundsXLeft = -61f;
    private float outOfBoundsXRight = 61f;
    private float outOfBoundsY = -7f;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 1.0f / 60.0f;  // Set FixedUpdate to run at 60 FPS
        playerJumpState = PlayerJumpState.JumpReleased;
        playerState = PlayerState.Idle;

        playerRigidBody.velocity = Vector2.zero;

        playerStateMachine = GetComponent<PlayerStateMachine>();
        playerStateMachine.Initialize(this); // Pass the PlayerMain instance
        animator = GetComponent<Animator>();              // Initializing the animator
    }

    public void Initialize(PlayerInputHandler pInputHandler)
    {
        controllerConnected = true;
        playerInputHandler = pInputHandler;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    // Update is called once per frame
    void Update() // make this a virtual void
    {
        if (controllerConnected)
        {
            moveInput = playerInputHandler.playerControls.move.ReadValue<Vector2>(); // grab input vector here
        }
        //animator.SetBool("isJumping", !isOnFloor); // animator checks if player is jumping still
        UpdateSpriteDirection();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            // When jump button is released
            if (playerJumpState != PlayerJumpState.JumpReleased) playerJumpState = PlayerJumpState.JumpReleased;
        }
        if (jumpCount <= 1)
        {
            if (context.started && !isAttacking) // jump pressed 
            {
                finishedJump = false;
                // When jump button is pressed
                playerJumpState = PlayerJumpState.JumpHeld; // TODO - CHANGE BACK ON COLL ENTER ON STAGE
                jumpFrameCounter = 0; // Reset frame counter
            }
            else if (context.canceled && !finishedJump) // jump released and havent jumped yet
            {
                shortHop = jumpFrameCounter < 5;
                // Determine if it's a short hop or a regular hop based on frame count
                PerformJump(shortHop);
                //animator.SetBool("isJumping", !isOnFloor); // Lets the animator know that the player is now jumping
            }
        }
    }
    public void PerformJump(bool isShortHop)
    {
        jumpCount++;
        finishedJump = true;
        if (isShortHop)
        {
            // Perform a short hop
            SetJumpVelocity(8f); // Lower jump force for short hop
        }
        else
        {
            // Perform a long hop
            SetJumpVelocity(12f); // Higher jump force for regular hop
        }
    }
    // FixedUpdate is called on a fixed time interval for physics updates
    public void SetJumpVelocity(float jumpForce)
    {
        currentVelocity.y = jumpForce; // Apply the upward force
        playerRigidBody.velocity = currentVelocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        
    }

    // ------------------------------------ ATTACK MOVES --------------------------------------- //
    public void NeutralLight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.NeutralLight;
            knockbackValue = 0.5f;
        }
    }
    public void ForwardLight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.ForwardLight;
            knockbackValue = 1.5f;
        }

    }
    public void DownLight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.DownLight;
            knockbackValue = 1.25f;
        }
    }
    public void NeutralUpHeavy(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.NeutralUpHeavy;
            knockbackValue = 3f;
        }
    }
    public void ForwardHeavy(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.ForwardHeavy;
            knockbackValue = 2.5f;
        }
    }
    public void DownHeavy(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.DownHeavy;
            knockbackValue = 2.5f;
        }
    }
    public void NeutralUpRanged(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.NeutralUpRanged;
            knockbackValue = 3f;
        }
    }
    public void ForwardRanged(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.ForwardRanged;
            knockbackValue = 2.5f;
        }
    }
    public void DownRanged(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            playerAttackType = PlayerAttackType.DownRanged;
            knockbackValue = 2.5f;
        }
    }


    // ------------------------------------ ATTACK MOVES --------------------------------------- //


    private void FixedUpdate() // make this a virtual void 
    {
        //currentVelocity.x = holdingMove ? 1 * moveSpeed : -1 * moveSpeed;
        //playerRigidBody.velocity = currentVelocity;
        //animator.SetFloat("xVelocity", Mathf.Abs(playerRigidBody.velocity.x));
        //animator.SetFloat("yVelocity", playerRigidBody.velocity.y);
        if (playerJumpState == PlayerJumpState.JumpHeld) jumpFrameCounter++; // track frames that jump button is held for 
        if (jumpFrameCounter == 5 && playerState == PlayerState.Grounded) // bro took too long, long hop it is 
        {
            if (isAttacking) // to prevent jump buffering while attacking
            {
                finishedJump = true; 
            }
            if (!isAttacking)
            {
                shortHop = false;
                PerformJump(shortHop);
            }
        }
        if (jumpCount == 1 && !finishedJump && jumpFrameCounter == 2)
        {
            PerformJump(false); // if already in air then do a long hop
        }
        if (transform.position.x > outOfBoundsXRight || transform.position.x < outOfBoundsXLeft || transform.position.y < outOfBoundsY)
        {
            Debug.Log("You have fallen off the map");
            fellOffMap = true;
        }
    }


    // ADJUST WHICH WAY SPRITE IS FACING
    void UpdateSpriteDirection()
    {
        if (isFacingRight && playerRigidBody.velocity.x < 0f || !isFacingRight && playerRigidBody.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("TopStage"))
        {
            isOnFloor = true;
            playerState = PlayerState.Grounded;
            jumpFrameCounter = 0; // Reset frame counter
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("TopStage"))
        {
            playerState = PlayerState.Airborne;
            isOnFloor = false;
        }
    }


}