using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LoadoutObject player1Loadout;
    public LoadoutObject player2Loadout;


    void Start()
    {
        //player1Loadout.ClearLoadout();
        //player2Loadout.ClearLoadout();
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
