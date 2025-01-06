using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PlayerMain playerMain;

    [HideInInspector]
    public PlayerMovingState playerMovingState;
    public PlayerAttackingState playerAttackingState;
    public PlayerIdleState playerIdleState;

    // takes argument playermain to grab the right object's main
    public void Initialize(PlayerMain main) 
    {
        playerMain = main; // Assign the PlayerMain instance
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter(null); // Enter the initial state
    }

    private void Awake()
    {
        playerMovingState = new PlayerMovingState(this);
        playerAttackingState = new PlayerAttackingState(this);
        //playerIdleState = new PlayerIdleState(this);
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
        
    }

    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.Exit();
        Debug.Log("Exiting: " + currentState.stateName + "/// Entering: " + newState.stateName);
        newState.Enter(currentState.stateName);
        currentState = newState;
    }

    protected virtual PlayerBaseState GetInitialState()
    {
        return playerMovingState; 
    }
}
