using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    // Timer variables for handling animation delay
    private bool isWaiting = false;
    private float waitTime = 0.05f; // 50 milliseconds
    private float timer = 0f;

    public PlayerIdleState(PlayerStateMachine stateMachine) : base("Idle", stateMachine)
    {
        this.stateName = "Idle";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        if (_sm.playerMain.playerState == PlayerMain.PlayerState.Grounded)
        {
            Debug.Log("Entered PlayerIdleState");

            // Play the "Run to Idle" animation if coming from moving state
            if (previousState == "Moving")
            {
                _sm.playerMain.animator.Play("PlayerRunToIdle");

                // Initialize the timer
                isWaiting = true;
                timer = waitTime; // timer set to 0.05sec


                if (isWaiting)
                {
                    // Decrement the timer by the time elapsed since the last frame
                    timer -= Time.deltaTime;

                    if (timer <= 0f)
                    {
                        // Timer has elapsed; switch to the idle animation
                        _sm.playerMain.animator.Play("PlayerKatanaIdle");
                        Debug.Log("Playing idle animation after transition");
                        isWaiting = false;
                    }
                }
            }
            else
            {
                _sm.playerMain.animator.Play("PlayerKatanaIdle");
            }
        }
        // else if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
        // {
        //     var verticalVelocity = _sm.playerMain.playerRigidBody.velocity.y;
            
        //     // Determine which jump animation to play based on vertical velocity
        //     if (verticalVelocity > 1)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpRise");
        //         Debug.Log("Playing jump rise animation");
        //     }
        //     else if (verticalVelocity < 4f && verticalVelocity > -4f && verticalVelocity != 0f)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpPeak");
        //         Debug.Log("Playing jump peak animation");
        //     }
        //     else if (verticalVelocity < -1)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpFall");
        //         Debug.Log("Playing jump fall animation");
        //     }
        // }
    }

    public override void UpdateLogic()
    {
        if (_sm.playerMain.isAttacking) // go to attacking state
        {
            _sm.ChangeState(_sm.playerAttackingState);
        }
        else if (_sm.playerMain.moveInput.x != 0) // go to moving state
        {
            _sm.ChangeState(_sm.playerMovingState);
        }
        // else if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
        // {
        //     var verticalVelocity = _sm.playerMain.playerRigidBody.velocity.y;
            
        //     // Update airborne animations based on vertical velocity
        //     if (verticalVelocity > 1)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpRise");
        //     }
        //     else if (verticalVelocity < 4f && verticalVelocity > -4f && verticalVelocity != 0f)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpPeak");
        //     }
        //     else if (verticalVelocity < -1)
        //     {
        //         _sm.playerMain.animator.Play("PlayerKatanaJumpFall");
        //     }
        // }
        // else if (isWaiting)
        // {
        //     // Decrement the timer
        //     timer -= Time.deltaTime;

        //     if (timer <= 0f)
        //     {
        //         // Timer has elapsed; switch to the idle animation
        //         _sm.playerMain.animator.Play("PlayerKatanaIdle");
        //         Debug.Log("Playing idle animation after transition");
        //         isWaiting = false;
        //     }
        // }
        else
        {
            if (counter > 0.5f && _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded)
            {
                counter = 0;
                // Replay idle animation
                _sm.playerMain.animator.Play("PlayerKatanaIdle");
                Debug.Log("Replaying idle animation");
            }
        }
        
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        // Stop any horizontal movement
        var currentVelocity = _sm.playerMain.playerRigidBody.velocity;
        currentVelocity.x = 0;
        _sm.playerMain.playerRigidBody.velocity = currentVelocity;
        
        base.UpdatePhysics();
    }
}
