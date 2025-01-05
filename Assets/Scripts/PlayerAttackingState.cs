using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttackingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private string previousState;
    private float counterMax; // in seconds

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base("Attacking", stateMachine)
    {
        this.stateName = "Attacking";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        this.previousState = previousState;

        switch (_sm.playerMain.playerAttackType)
        {
            case PlayerMain.PlayerAttackType.NeutralLight :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play NeutralLight air animation
                    // set counterMax to animation length
                    
                }
                else // Grounded
                {
                    // play NeutralLight animation
                    // set counterMax to animation length
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardLight :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play ForwardLight air animation
                    // set counterMax to animation length
                    Debug.Log("playing forward light air attack");
                }
                else // Grounded
                {
                    // play ForwardLight animation
                    // set counterMax to animation length
                    Debug.Log("playing forward light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.DownLight :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play DownLight air animation
                    // set counterMax to animation length
                }
                else // Grounded
                {
                    // play DownLight animation'
                    // set counterMax to animation length
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpHeavy :
               
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play NeutralUpHeavy air animation
                    // set counterMax to animation length
                }
                else // Grounded
                {
                    // play NeutralUpHeavy animation
                    // set counterMax to animation length
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardHeavy :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play ForwardHeavy air animation
                    // set counterMax to animation length
                }
                else // Grounded
                {
                    // play ForwardHeavy animation
                    // set counterMax to animation length
                }
                break;
            case PlayerMain.PlayerAttackType.DownHeavy :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play DownHeavy air animation
                    // set counterMax to animation length
                }
                else // Grounded
                {
                    // play DownHeavy animation
                    // set counterMax to animation length
                }
                break;
        }

        
    }

    public override void UpdateLogic()
    {
        // TODO: combo window --> could be 0.5 sec, starts at
        // last .25 sec of animation, and ends .25 sec after 
        // if attack has a combo
        //   if counter >= counterMax - 0.25 then start combo window
        // it should carry on incrementing to the next state
        // assuming that state isnt hurt/dead state

        if (counter > counterMax)
        {
            if (previousState == "Moving") _sm.ChangeState(_sm.playerMovingState);
            //else _sm.ChangeState(_sm.playerIdleState); // not implemented yet
        }

        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        
        base.UpdatePhysics();
    }
}
