using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerDescriptionDisplay : MonoBehaviour
{
    public TextMeshProUGUI descriptionText; // Assign in Inspector

    private void Start()
    {
        ClearDescription();
    }

    public void ShowDescription(string description)
    {
        descriptionText.text = description;
    }

    public void ClearDescription()
    {
        descriptionText.text = "Choose a power";
    }
}