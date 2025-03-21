using UnityEngine;

public class MenuSettings : MonoBehaviour
{
    public void SetMenuMusicVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }
} 