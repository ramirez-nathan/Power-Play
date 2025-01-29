using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player1HealthScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    public PlayerMain player1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       healthText.text = "Player 1 HP: " + player1.currentHealth.ToString();
    }
}
