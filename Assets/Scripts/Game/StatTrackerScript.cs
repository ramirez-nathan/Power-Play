using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTrackerScript : MonoBehaviour
{
    // Components and References
    public PlayerMain player;                     // Reference to the player for retrieving stats
    public static StatTrackerScript Instance;

    // Stats
    private int stocksLeft = 0;
    private int totalDamageDealt = 0;
    private int numKills = 0;
    private float killDeathRatio = 0f;
    private int attacksLanded = 0;
    private float MatchDuration = 0f;



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

    // Methods to update stats
    public void AddDamage(int damage)
    {
        totalDamageDealt += damage;
    }

    public void AddKills(int kills)
    {
        numKills += kills;
    }

    public void ResetStats()
    {
        stocksLeft = 0;
        totalDamageDealt = 0;
        numKills = 0;
        attacksLanded = 0;
        MatchDuration = 0f;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
