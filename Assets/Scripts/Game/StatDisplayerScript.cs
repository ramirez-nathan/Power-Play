using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatDisplayerScript : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI KDRatioText;
    public TextMeshProUGUI StocksLeftText;
    public TextMeshProUGUI DamageDealtText;
    public TextMeshProUGUI AttacksLandedText;
    public TextMeshProUGUI MatchDurationText;

    private string FormatTime(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.FloorToInt(totalSeconds % 60f);
        return $"{minutes:00}:{seconds:00}";
    }

    public void ShowEndGameStats()
    {
        KDRatioText.text = "KD Ratio: 2.5";
        StocksLeftText.text = "Stocks Left: 3";
        DamageDealtText.text = "Damage Dealt: 150";
        AttacksLandedText.text = "Attacks Landed: 14";
        MatchDurationText.text = "Match Duration: 56s";
    }


    // Start is called before the first frame update
    void Start()
    {
        ShowEndGameStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
