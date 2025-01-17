using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private PlayerStateMachine _sm;

    // Timer variables for handling animation delay
    private bool isWaiting = false;
    //private float waitTime = 0.05f; // 50 milliseconds
    //private float timer = 0f;
    

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
                //_sm.StartCoroutine(_sm.PlayLockedAnimation("PlayerRunToIdle", 0.05f));
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
        else
        {
            if (!isLockAnimating && _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded)
            { 
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
