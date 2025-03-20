using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttackingState : PlayerBaseState
{
    private PlayerStateMachine _sm;
    private string previousState;
    private float counterMax = 0.5f; // in seconds

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base("Attacking", stateMachine)
    {
        this.stateName = "Attacking";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        this.previousState = previousState;
        //Debug.Log("Entering Attack state");
        _sm.playerMain.attackHitbox.hitEnemies.Clear(); // new attack so clear the list
        var atkDmg = 0;
        var xDirection = _sm.playerMain.isFacingRight ? Vector2.right : Vector2.left;
        switch (_sm.playerMain.playerAttackType)
        {
            case PlayerMain.PlayerAttackType.NeutralLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaAirAttack");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, xDirection);
                    //Debug.Log("playing neutral light air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerKatanaNeutralLight");
                    counterMax = 0.6f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, xDirection);
                    //Debug.Log("playing neutral light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                { 
                    _sm.playerMain.animator.Play("PlayerKatanaAirForward");
                    counterMax = 0.62f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, xDirection);
                    //Debug.Log("playing forward light air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerKatanaForwardLight");
                    counterMax = 0.52f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, xDirection);
                    //Debug.Log("playing forward light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.DownLight:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaAirAttackDown");
                    counterMax = 0.6f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, Vector2.down);
                    //Debug.Log("playing down light air attack");
                }
                else // Grounded
                {
                    counterMax = 0.0f;
                    //Debug.Log("playing down light attack");
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpHeavy:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaAirHeavyUp");
                    counterMax = 0.6f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(15);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 6f, Vector2.up);
                    //Debug.Log("playing neutral up heavy air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerKatanaNeutralHeavy");
                    counterMax = 0.52f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(15);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, new Vector2(0.3f, 1f));
                    //Debug.Log("playing neutral up heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardHeavy:
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaAirForwardHeavy");
                    counterMax = 0.62f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(15);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 5f, xDirection);
                    //Debug.Log("playing forward heavy air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerKatanaForwardHeavy");
                    counterMax = 0.87f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(15);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 4f, xDirection);
                    //Debug.Log("playing forward heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.DownHeavy:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerKatanaAirDownHeavy");
                    counterMax = 0.83f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(20);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 8f, Vector2.down);
                    //Debug.Log("playing down heavy air attack");
                }
                else // Grounded
                {
                    //_sm.playerMain.animator.Play("PlayerKatanaNeutralHeavyDown");
                    counterMax = 0.0f;
                    
                    //Debug.Log("playing down heavy attack");
                }
                break;
            case PlayerMain.PlayerAttackType.ForwardRanged:
                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerBlasterAir");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(5);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 2f, xDirection);
                    //Debug.Log("playing forward ranged air attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerBlasterNeutral");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(5);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 2f, xDirection);
                    //Debug.Log("playing forward ranged attack");
                }
                break;
            case PlayerMain.PlayerAttackType.NeutralUpRanged:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerBlasterAirUp");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, Vector2.up);
                    //Debug.Log("playing neutral up ranged attack");
                }
                else // Grounded
                {
                    _sm.playerMain.animator.Play("PlayerBlasterUp");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, Vector2.up);
                    //Debug.Log("playing neutral up ranged attack");
                }
                break;
            
            case PlayerMain.PlayerAttackType.DownRanged:

                if (_sm.playerMain.playerState == PlayerMain.PlayerState.Airborne)
                {
                    _sm.playerMain.animator.Play("PlayerBlasterAirDown");
                    counterMax = 0.43f;
                    atkDmg = _sm.playerMain.DamageAfterBuffs(10);
                    _sm.playerMain.attackHitbox.Initialize(atkDmg, 3f, Vector2.down);
                    //Debug.Log("playing down ranged air attack");
                }
                else // Grounded
                {
                    counterMax = 0.0f;
                    //Debug.Log("playing down ranged attack");
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
