using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2HealthScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField]
    public PlayerMain player2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Player 2 HP: " + player2.currentHealth.ToString();
    }
}
