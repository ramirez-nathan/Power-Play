using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private string previousState;
    private float counter;
    private float counterMax;

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base("Attacking", stateMachine)
    {
        this.stateName = "Attacking";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        counter = 0;
        this.previousState = previousState;

        switch (_sm.playerMain.playerAttackType)
        {
            case PlayerMain.PlayerAttackType.NeutralLight :

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play NeutralLight air animation
                }
                else
                {
                    // play NeutralLight animation
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardLight :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play ForwardLight air animation
                }
                else
                {
                    // play ForwardLight animation
                }
                break;
            case PlayerMain.PlayerAttackType.DownLight :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play DownLight air animation
                }
                else
                {
                    // play DownLight animation
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpHeavy :
               
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play NeutralUpHeavy air animation
                }
                else
                {
                    // play NeutralUpHeavy animation
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardHeavy :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play ForwardHeavy air animation
                }
                else
                {
                    // play ForwardHeavy animation
                }
                break;
            case PlayerMain.PlayerAttackType.DownHeavy :
                
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    // play DownHeavy air animation
                }
                else
                {
                    // play DownHeavy animation
                }
                break;
        }

        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        

    }

    public override void UpdatePhysics()
    {
        
        base.UpdatePhysics();
    }
}
