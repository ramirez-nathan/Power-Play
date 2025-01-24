using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    // Timer variables for handling animation delay
    private bool isWaiting = false;
    private float waitTime = 0.00f; // Match the transition time from idle state
    private float timer = 0f;
    private bool isLockAnimating = false; // Added to prevent animation interruption

    public PlayerMovingState(PlayerStateMachine stateMachine) : base("Moving", stateMachine)
    {
        this.stateName = "Moving";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        if (_sm.playerMain.playerState == PlayerMain.PlayerState.Grounded)
        {
            Debug.Log("Entered PlayerMovingState");

            if (previousState == "Idle")
            {
                // Play the "Idle to Run" animation
                _sm.playerMain.animator.Play("PlayerKatanaIdleToRun");

                // Initialize the timer
                isWaiting = true;
                timer = waitTime;
                isLockAnimating = true; // Prevent animation interruption
            }
            else
            {
                _sm.playerMain.animator.Play("PlayerKatanaRunWithDust");
                Debug.Log("Playing moving animation upon enter, did not come from idle");
            }
        }
        // else // We're airborne
        // {
        //     var verticalVelocity = _sm.playerMain.playerRigidBody.velocity.y;
            
        //     // Determine which jump animation to play based on vertical velocity
        //     if (verticalVelocity > 0)
        //     {
        //         // Rising
        //         _sm.playerMain.animator.Play("PlayerJumpRise");
        //         Debug.Log("Playing jump rise animation");
        //     }
        //     else if (verticalVelocity < 0)
        //     {
        //         // Falling
        //         _sm.playerMain.animator.Play("PlayerJumpFall");
        //         Debug.Log("Playing jump fall animation");
        //     }
        //     else
        //     {
        //         // At peak of jump
        //         _sm.playerMain.animator.Play("PlayerJumpPeak");
        //         Debug.Log("Playing jump peak animation");
        //     }
        // }

    }

    public override void UpdateLogic()
    {
        if (_sm.playerMain.isAttacking) // go to attacking state
        {
            _sm.ChangeState(_sm.playerAttackingState);
        }
        else if (_sm.playerMain.playerRigidBody.velocity.x == 0 && 
                 _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded) // go to idle state
        {
            Debug.Log("Entering Idle State from Moving");
            _sm.ChangeState(_sm.playerIdleState);
        }
        else if (isWaiting)
        {
            // Update timer
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Timer has elapsed; switch to the run animation
                _sm.playerMain.animator.Play("PlayerKatanaRunWithDust");
                Debug.Log("Playing run animation after transition");
                isWaiting = false;
                isLockAnimating = false; // Allow new animations
            }
        }
        else
        {
            if (counter > 0.5 && _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded && 
                _sm.playerMain.playerRigidBody.velocity.x != 0 && !isLockAnimating) 
            {
                counter = 0;
                _sm.playerMain.animator.Play("PlayerKatanaRunWithDust");
                Debug.Log("replaying moving animation");
            }
            else if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
            {
                var verticalVelocity = _sm.playerMain.playerRigidBody.velocity.y;

                if (verticalVelocity > 1)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaJumpRise");
                    Debug.Log("Playing jump rise animation");
                }
                else if (verticalVelocity < 4f && verticalVelocity > -4f && verticalVelocity != 0f)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaJumpPeak");
                    Debug.Log("Playing jump peak animation");
                }
                else if (verticalVelocity < -1)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaJumpFall");
                    Debug.Log("Playing jump fall animation");
                }
                else
                {
                    _sm.playerMain.animator.Play("PlayerKatanaIdle");
                    Debug.Log("Playing idle animation");
                }
            }
        }
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        var input = _sm.playerMain.moveInput;
        
        var currentVelocity = _sm.playerMain.playerRigidBody.velocity;
        currentVelocity.x = input.x * _sm.playerMain.moveSpeed;
        _sm.playerMain.playerRigidBody.velocity = currentVelocity;

        
        base.UpdatePhysics();
    }
}
