using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Loadout", menuName = "Loadout System/Loadout")]
public class LoadoutObject : ScriptableObject
{
    public List<PowerObject> Container = new List<PowerObject>();

    private int maxLoadoutSize = 5;

    public bool AddPower(PowerObject power)
    {
        if (Container.Count >= maxLoadoutSize) return false; // Prevent overfilling
        if (Container.Contains(power)) return false; // Prevent duplicates (optional)

        Container.Add(power);
        return true;
    }

    public void RemovePower(PowerObject power)
    {
        if (Container.Contains(power))
        {
            Container.Remove(power);
        }
    }
    void OnApplicationQuit()
    {
        Container.Clear(); // Clear the loadout when quitting the game
    }
    private void OnDisable()
    {
        Container.Clear();
    }

}

[System.Serializable]
public class LoadoutSlot
{
    public PowerObject power;
    public bool isEquippable = true;
    public LoadoutSlot(PowerObject power)
    {
        this.power = power;
    }
    
}
