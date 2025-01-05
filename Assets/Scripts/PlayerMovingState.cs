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
            Debug.Log("Playing moving animation upon enter");
        }
        else // airborne
        {

            // some logic for whether to 
            // play jumping animation 
            // or play falling animation 
        }

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
                Debug.Log("replaying moving animation");
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
