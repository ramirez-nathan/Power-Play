using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerDeadState : PlayerBaseState
{

    private PlayerStateMachine _sm;
    [SerializeField] private bool isRespawning = false;
    [SerializeField] private bool preRespawning = false;
    private float respawnTimer = 1.5f;
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
                _sm.playerMain.audioManager.PlayDeathSound();
            }
            else
            {
                _sm.playerMain.audioManager.PlayDeathSound();
                Debug.Log("no death sound");
            }

            // Decrement the number of lives
            _sm.playerMain.numStocks--;
            
            // Destroy the player if we have 0 lives left
            if (_sm.playerMain.numStocks == 0)
            {
                Debug.Log("Lost last stock, game over");
                preRespawning = true;
                _sm.playerMain.animator.Play("PlayerDie");

                Debug.Log($"Destroying object, player numstocks is {_sm.playerMain.numStocks}");
                _sm.playerMain.gameOverScreen.ShowGameOver();
                preRespawning = false;
                GameObject.Destroy(_sm.playerMain.gameObject);
                
            }
            else
            {
                Debug.Log("Respawning");
                preRespawning = true;
                _sm.playerMain.animator.Play("PlayerDie");
                // _sm.playerMain.sprite.enabled = false;
                isRespawning = true;
            }
        }
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _sm.playerMain.fellOffMap = false;

        _sm.playerMain.playerRigidBody.gravityScale = 0f;
        _sm.playerMain.playerRigidBody.velocity = Vector3.zero;
        if (preRespawning)
        {
            _sm.playerMain.playerRigidBody.velocity = Vector3.zero;
            preRespawnTimer -= Time.deltaTime;
            
            if (preRespawnTimer <= 0) 
            { 
                preRespawning = false;
                preRespawnTimer = 1.5f;
            }
        }
        else if (isRespawning && !preRespawning)
        {
            _sm.playerMain.transform.position = _sm.playerMain.spawnPoint.position;
            // _sm.playerMain.sprite.enabled = true;
            // replay respawn animation here
            _sm.playerMain.animator.Play("PlayerRespawn");
            respawnTimer -= Time.deltaTime;
            _sm.playerMain.isVulnerable = false; // invulnerable during this 
        }
        var moveInput = _sm.playerMain.moveInput;
        // If ANY movement input at all -- square it to get abs value
        if (!preRespawning && (respawnTimer <= 0 || moveInput.x * moveInput.x > 0 || moveInput.y * moveInput.y > 0)) 
        {
            respawnTimer = 4f;
            isRespawning = false;
            _sm.playerMain.isVulnerable = true;
            _sm.playerMain.isAlive = true;
            Debug.Log("Stopped Respawning");
            _sm.playerMain.currentHealth = 100;
            _sm.playerMain.playerRigidBody.gravityScale = 3f;

            _sm.ChangeState(_sm.playerMovingState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
