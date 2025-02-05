using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeadState : PlayerBaseState
{

    private PlayerStateMachine _sm;
    [SerializeField] private bool isRespawning = false;
    [SerializeField] private bool preRespawning = false;
    private float respawnTimer = 4f;
    private float preRespawnTimer = 1.5f;

    public PlayerDeadState(PlayerStateMachine stateMachine) : base("Idle", stateMachine)
    {
        this.stateName = "Dead";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        // maybe play the respawn animation here?
        if (_sm.playerMain.deathSound != null && _sm.playerMain.deathSound.clip != null)
        {
            // Play the sound at the character's position
            if (_sm.playerMain.fellOffMap)
            {
                AudioSource.PlayClipAtPoint(_sm.playerMain.deathSound.clip, _sm.playerMain.transform.position);
            }
            else
            {
                Debug.Log("no death sound");
            }

            // Decrement the number of lives
            _sm.playerMain.numStocks--;
            
            // Destroy the player if we have 0 lives left
            if (_sm.playerMain.numStocks == 0)
            {
                GameObject.Destroy(_sm.playerMain.gameObject);
                
                _sm.playerMain.gameOverScreen.ShowGameOver();
            }
            else
            {
                Debug.Log("Respawning");
                preRespawning = true;
                isRespawning = true;
            }
        }
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _sm.playerMain.fellOffMap = false;
        _sm.playerMain.isAlive = true;
        if (preRespawning)
        {
            preRespawnTimer -= Time.deltaTime;
            if (preRespawnTimer <= 0) 
            { 
                preRespawning = false;
                preRespawnTimer = 1.5f;
            }
        }
        else if (isRespawning && !preRespawning)
        {
            _sm.playerMain.playerRigidBody.gravityScale = 0f;
            _sm.playerMain.transform.position = _sm.playerMain.spawnPoint.position;
            // replay respawn animation here
            respawnTimer -= Time.deltaTime;
            _sm.playerMain.isVulnerable = false; // invulnerable during this 
        }
        var moveInput = _sm.playerMain.moveInput;
        // If ANY movement input at all -- square it to get abs value
        if (respawnTimer <= 0 || moveInput.x * moveInput.x > 0 || moveInput.y * moveInput.y > 0) 
        {
            respawnTimer = 4f;
            isRespawning = false;
            _sm.playerMain.isVulnerable = true;
            Debug.Log("Stopped Respawning");
            _sm.playerMain.currentHealth = 100;
            _sm.playerMain.playerRigidBody.gravityScale = 1f;
            _sm.ChangeState(_sm.playerMovingState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
