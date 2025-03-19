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
    private AudioManager audioManager;


    public PlayerIdleState(PlayerStateMachine stateMachine) : base("Idle", stateMachine)
    {
        this.stateName = "Idle";
        _sm = stateMachine;
        audioManager = _sm.playerMain.audioManager;

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
                audioManager.StopRunningSound();
                
                // Initialize the timer
                isWaiting = true;
                timer = waitTime;
                isLockAnimating = true; // Prevent animation interruption
            }
            else
            {
                audioManager.StopRunningSound();
                _sm.playerMain.animator.Play("PlayerKatanaIdle");
            }
        }
    }

    public override void UpdateLogic()
    {
        if (_sm.playerMain.isAttacking) // go to attacking state
        {
            _sm.ChangeState(_sm.playerAttackingState);
        }
        else if (_sm.playerMain.moveInput.x != 0f || _sm.playerMain.playerState == PlayerMain.PlayerState.Airborne) // go to moving state
        {
            Debug.Log("Changing from Idle to Moving");
            _sm.ChangeState(_sm.playerMovingState);
        }
        else if (isWaiting) // this takes care of transition animation INTO the idle state
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
        else // this takes care of standing still, and replaying the animation
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
