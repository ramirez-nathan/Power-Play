using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverTextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField]
    public PlayerMain player1;
    public PlayerMain player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null)
        {
            winnerText.text = "Game!\nPlayer 2 Wins!";
        }

        else if (player2 == null)
        {
            winnerText.text = "Game!\nPlayer 1 Wins!";
        }
    }
}
