using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LoadoutObject player1Loadout; // list of powers
    public LoadoutObject player2Loadout; // lust of powers 
    // store in gamemanager during loadout
    // assign to players in start


    public void ClearLoadouts()
    {
        player1Loadout.Container.Clear();
        player2Loadout.Container.Clear();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
