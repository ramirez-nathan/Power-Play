using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTrackerScript : MonoBehaviour
{
    // Components and References
    public PlayerMain player;                     // Reference to the player for retrieving stats
    public static StatTrackerScript Instance;

    // Win/Loss Record
    private int totalMatchesPlayed = 0;
    private int totalWins = 0;
    private float winrate = 0f;


    // Damage Metrics
    private int totalDamageDealt = 0;
    private int totalDamageTaken = 0;
    private int totalKills = 0;
    private int totalDeaths = 0;
    private float killDeathRatio = 0f;


    // Average Match Length
    private float longestMatchDuration = 0f;
    private float shortestMatchDuration = 0f;
    private float averageMatchDuration = 0f;



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

    public void AddMatch(bool won)
    {
        totalMatchesPlayed++;
        if (won) totalWins++;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
