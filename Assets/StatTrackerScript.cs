using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTrackerScript : MonoBehaviour
{
    // Components and References
    public PlayerMain player;               // Reference to the player for retrieving stats
    // public GameObject stage;             // Reference to the stage GameObject (for ground checks).
    // private SpriteRenderer spriteRenderer; // SpriteRenderer for changing player sprites.
    // public AudioSource deathSound;       // A sound that gets played when the character gets destroyed
    // public Collider2D attackCollider;    // The collider representing the player's attack hitbox
    // public enemyScript enemyScwipt;      // Reference to enemy code
    // public gameOverScreen gameOverScween; // The game over screen
    public static StatTrackerScript Instance;

    public int totalDamageDealt = 0;
    public int totalMatchesPlayed = 0;
    public int totalWins = 0;


    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
