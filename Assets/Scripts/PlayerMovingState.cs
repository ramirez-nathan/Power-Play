using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
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
            // play moving animation
            _sm.playerMain.animator.Play("PlayerRun");
            Debug.Log("Playing moving animation upon enter");
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
        else if (_sm.playerMain.moveInput.x == 0 && 
                 _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded) // go to idle state
        {
            //_sm.ChangeState(_sm.playerIdleState);
            _sm.playerMain.animator.Play("PlayerKatanaIdle");
        }
        // Logic

        // add logic for being hit

        // for dying

        else
        {
            if (counter > 0.5 && _sm.playerMain.playerState == PlayerMain.PlayerState.Grounded) // adjust value to match actual animation length 
            {
                counter = 0;
                // play moving animation again
                _sm.playerMain.animator.Play("PlayerRun");
                Debug.Log("replaying moving animation");
            } else if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)// We're airborne
            {
                var verticalVelocity = _sm.playerMain.playerRigidBody.velocity.y;
                
                // Determine which jump animation to play based on vertical velocity
                if (verticalVelocity > 1 )
                {
                    // Rising
                    _sm.playerMain.animator.Play("PlayerKatanaJumpRise");
                    Debug.Log("Playing jump rise animation");
                }
                else if (verticalVelocity < 4f && verticalVelocity > -4f && verticalVelocity != 0f)
                {
                    // At peak of jump
                    _sm.playerMain.animator.Play("PlayerKatanaJumpPeak");
                    Debug.Log("Playing jump peak animation");
                }
                else if (verticalVelocity < -1)
                {
                    // Falling
                    _sm.playerMain.animator.Play("PlayerKatanaJumpFall");
                    Debug.Log("Playing jump fall animation");
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
