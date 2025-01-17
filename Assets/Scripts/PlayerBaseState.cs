using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState 
{
    public string name;

    public string stateName;
    public float counter;
    protected PlayerStateMachine playerStateMachine;
    public bool isLockAnimating = false;
    // Start is called before the first frame update
    public PlayerBaseState(string name, PlayerStateMachine stateMachine)
    {
        this.name = name;
        this.playerStateMachine = stateMachine;
    }

    public virtual void Enter(string previousState) {
        counter = 0;
    }
    public virtual void UpdateLogic() {
        counter += Time.deltaTime;
    }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
