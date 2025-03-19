using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttackingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private string previousState;
    private float counterMax = 0.5f; // in seconds
    private AudioManager audioManager;


    

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base("Attacking", stateMachine)
    {
        this.stateName = "Attacking";
        _sm = stateMachine;
        audioManager = _sm.playerMain.audioManager;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        this.previousState = previousState;
        Debug.Log("Entering Attack state");
        counterMax = 0.5f;
        switch (_sm.playerMain.playerAttackType)
        {
            case PlayerMain.PlayerAttackType.NeutralLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    counterMax = 0.25f;
                    Debug.Log("counter start = " + counter);
                    _sm.playerMain.animator.Play("PlayerKatanaAirAttack");
                    audioManager.PlayLightKatanaSound();

                    // set counterMax to animation length

                    Debug.Log("playing neutral light air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerKatanaNeutralLight");
                    audioManager.PlayLightKatanaSound();

                    // set counterMax to animation length
                    Debug.Log("playing neutral light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    _sm.playerMain.animator.Play("PlayerKatanaAirForward");
                    audioManager.PlayLightKatanaSound();
                    // set counterMax to animation length
                    Debug.Log("playing forward light air attack");
                }
                else // Grounded
                {
                    
                    _sm.playerMain.animator.Play("PlayerKatanaForwardLight");
                    audioManager.PlayLightKatanaSound();
                    // set counterMax to animation length
                    Debug.Log("playing forward light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.DownLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    _sm.playerMain.animator.Play("PlayerKatanaAirAttackDown");
                    audioManager.PlayLightKatanaSound();
                    // set counterMax to animation length
                    Debug.Log("playing down light air attack");
                }
                else // Grounded
                {
                   
                    // set counterMax to animation length
                    Debug.Log("playing down light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpHeavy:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    _sm.playerMain.animator.Play("PlayerKatanaAirHeavyUp");
                    audioManager.PlayHeavyKatanaSound();
                    // set counterMax to animation length
                    Debug.Log("playing neutral up heavy air attack");
                }
                else // Grounded
                {
                    
                    _sm.playerMain.animator.Play("PlayerKatanaNeutralHeavy");
                    audioManager.PlayHeavyKatanaSound();

                    // set counterMax to animation length
                    Debug.Log("playing neutral up heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardHeavy:
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    // set counterMax to animation length
                    _sm.playerMain.animator.Play("PlayerKatanaAirForwardHeavy");
                    audioManager.PlayHeavyKatanaSound();
                    Debug.Log("playing forward heavy air attack");
                }
                else // Grounded
                {
                    // play ForwardHeavy animation
                    _sm.playerMain.animator.Play("PlayerKatanaForwardHeavy");
                    audioManager.PlayHeavyKatanaSound();
                    
                    // set counterMax to animation length
                    Debug.Log("playing forward heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.DownHeavy:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    counterMax = 1.08f;
                    // set counterMax to animation length
                    _sm.playerMain.animator.Play("PlayerKatanaAirDownHeavy");
                    audioManager.PlayHeavyKatanaSound();
                    Debug.Log("playing down heavy air attack");
                }
                else // Grounded
                {
                    // play DownHeavy animation
                    _sm.playerMain.animator.Play("PlayerKatanaNeutralHeavyDown");
                    audioManager.PlayHeavyKatanaSound();
                    // set counterMax to animation length
                    Debug.Log("playing down heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardRanged:
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerBlasterAir");
                    audioManager.PlayBlasterSound();
                    // set counterMax to animation length
                    Debug.Log("playing forward ranged air attack");
                }
                else // Grounded
                {
                    // set counterMax to animation length
                    _sm.playerMain.animator.Play("PlayerBlasterNeutral");
                    audioManager.PlayBlasterSound();
                    Debug.Log("playing forward ranged attack");
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpRanged:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    _sm.playerMain.animator.Play("PlayerBlasterAirUp");
                    audioManager.PlayBlasterSound();
                    // set counterMax to animation length
                    Debug.Log("playing neutral up ranged attack");
                }
                else // Grounded
                {
                    
                    // set counterMax to animation length
                    _sm.playerMain.animator.Play("PlayerBlasterUp");
                    audioManager.PlayBlasterSound();
                    Debug.Log("playing neutral up ranged attack");
                }
                break;
            
            case PlayerMain.PlayerAttackType.DownRanged:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    
                    _sm.playerMain.animator.Play("PlayerBlasterAirDown");
                    audioManager.PlayBlasterSound();
                    // set counterMax to animation length
                    Debug.Log("playing down ranged air attack");
                }
                else // Grounded
                {
                    
                    // set counterMax to animation length
                    Debug.Log("playing down ranged attack");
                }
                break;
        }
    }

    public override void UpdateLogic()
    {
        // TODO: combo window --> could be 0.5 sec, starts at
        // last .25 sec of animation, and ends .25 sec after 
        // if attack has a combo && attack made contact 
        //   if counter >= counterMax - 0.25 then start combo window 
        // it should carry on incrementing to the next state 
        // assuming that state isnt hurt/dead state 

        if (counter > counterMax)
        {
            //Debug.Log("counter end = " + counter);
            _sm.playerMain.isAttacking = false;
            if (previousState == "Moving") _sm.ChangeState(_sm.playerMovingState);
            else if (previousState == "Idle") _sm.ChangeState(_sm.playerIdleState); 
        }

        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        
        base.UpdatePhysics();
    }
}
