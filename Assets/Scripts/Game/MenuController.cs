using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;

    void Start()
    {
        // Set initial slider value
        musicVolumeSlider.value = 0.7f;
        
        // Add listener for when slider changes
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
    }

    void OnMusicVolumeChanged(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }
} 