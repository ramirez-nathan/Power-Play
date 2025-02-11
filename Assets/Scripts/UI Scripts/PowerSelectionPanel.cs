using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelectionPanel : MonoBehaviour
{
    public LoadoutObject playerLoadout;
    public Transform powerButtonContainer; // Panel that holds power buttons
    public GameObject powerButtonPrefab; // Prefab for UI buttons
    [SerializeField] public int playerIndex = 0;

    public List<PowerObject> availablePowers; // List of all selectable powers
    private List<GameObject> spawnedButtons = new List<GameObject>();

    void Start()
    {
        PopulatePowerButtons();
    }

    void PopulatePowerButtons()
    {
        // Clear any existing buttons before repopulating
        foreach (var btn in spawnedButtons)
        {
            Destroy(btn);
        }
        spawnedButtons.Clear();

        foreach (var power in availablePowers)
        {
            GameObject buttonObj = Instantiate(powerButtonPrefab, powerButtonContainer);
            Button btn = buttonObj.GetComponent<Button>();
            btn.onClick.AddListener(() => SelectPower(power));

            Text buttonText = buttonObj.GetComponentInChildren<Text>();

            if (buttonText != null)
            {
                buttonText.text = power.name;
            }

            spawnedButtons.Add(buttonObj);
        }
    }

    public void SelectPower(PowerObject power)
    {
        if (playerLoadout.AddPower(power))
        {
            Debug.Log($"{power.powerName} added to Player {playerIndex}'s loadout!");
            UpdateUI();
        }
        else
        {
            Debug.Log("Loadout is full or power is already equipped!");
        }
    }

    public void DeselectPower(PowerObject power)
    {
        playerLoadout.RemovePower(power);
        Debug.Log($"{power.powerName} removed from loadout.");
        UpdateUI();
    }

    public void ConfirmLoadoutSelection()
    {
        if (playerIndex == 1)
            GameManager.Instance.player1Loadout = playerLoadout;
        else if (playerIndex == 2)
            GameManager.Instance.player2Loadout = playerLoadout;

        //Debug.Log($"Player {playerIndex} confirmed loadout: {playerLoadout.name}");
    }

    void UpdateUI()
    {
        // TODO: Add UI updates (e.g., highlight selected powers, disable full loadout)
    }
}
