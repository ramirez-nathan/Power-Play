using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    // Timer variables for handling animation delay
    private bool isWaiting = false;
    private float waitTime = 0.20f;
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
                Debug.Log("Playing transition animation: Run to Idle");
                _sm.playerMain.animator.Play("PlayerKatanaRunToIdle");
                
                // Initialize the timer
                isWaiting = true;
                timer = waitTime;
                isLockAnimating = true; // Prevent animation interruption
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
        else if (_sm.playerMain.moveInput.x != 0f || 
                 _sm.playerMain.playerState == PlayerMain.PlayerState.Airborne) // go to moving state
        {
            Debug.Log("Changing from Idle to Moving");
            _sm.ChangeState(_sm.playerMovingState);
        }
        else if (isWaiting)
        {
            // Update timer
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Timer has elapsed; switch to the idle animation
                _sm.playerMain.animator.Play("PlayerKatanaIdle");
                Debug.Log("Playing idle animation after transition");
                isWaiting = false;
                isLockAnimating = false; // Allow new animations
            }
        }
        else
        {
            if (!isLockAnimating && _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded)
            { 
                _sm.playerMain.animator.Play("PlayerKatanaIdle");
            }
        }
        
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
