using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource runningSource; // Separate source for looping run sound

    [Header("Audio Clips")]
    // public AudioClip backgroundMusic;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip lightKatana;
    public AudioClip heavyKatana;
    public AudioClip blaster;
    public AudioClip hurt;
    public AudioClip die;
    public AudioClip respawn;

    [Header("Volume Levels")]
    [Range(0f, 1f)]
    [SerializeField] private float masterVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 0.5f;
    [Range(0f, 1f)]
    [SerializeField] private float sfxVolume = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float runningVolume = 0.6f;

    [Header("Individual SFX Volumes")]
    [Range(0f, 1f)]
    [SerializeField] private float jumpVolume = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float lightKatanaVolume = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float heavyKatanaVolume = 0.9f;
    [Range(0f, 1f)]
    [SerializeField] private float blasterVolume = 0.7f;
    [Range(0f, 1f)]
    [SerializeField] private float hurtVolume = 0.8f;
    [Range(0f, 1f)]
    [SerializeField] private float deathVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float respawnVolume = 0.8f;

    [Header("Pitch Settings")]
    [SerializeField] private float basePitch = 1f;
    [SerializeField] private float pitchVariation = 0.1f; // Changed to a smaller value
    
    [Header("Running Sound Settings")]
    [SerializeField] private float runSoundInterval = 0.3f;
    private bool isRunning = false;

    private void Start()
    {
        // musicSource.clip = backgroundMusic;
        // musicSource.Play();

        // Set up running sound source
        if (runningSource == null)
        {
            runningSource = gameObject.AddComponent<AudioSource>();
        }
        runningSource.clip = run;
        runningSource.loop = false;
        runningSource.playOnAwake = false;
        
        // Initialize volumes
        UpdateVolumes();
    }

    public void UpdateVolumes()
    {
        if (musicSource != null)
            musicSource.volume = masterVolume * musicVolume;
        
        if (SFXSource != null)
            SFXSource.volume = masterVolume * sfxVolume;
        
        if (runningSource != null)
            runningSource.volume = masterVolume * runningVolume;
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        UpdateVolumes();
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
            musicSource.volume = masterVolume * musicVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        if (SFXSource != null)
            SFXSource.volume = masterVolume * sfxVolume;
    }

    public void StartRunningSound()
    {
        if (!isRunning)
        {
            isRunning = true;
            InvokeRepeating("PlayRunSoundWithVariation", 0f, runSoundInterval);
        }
    }

    public void StopRunningSound()
    {
        if (isRunning)
        {
            isRunning = false;
            CancelInvoke("PlayRunSoundWithVariation");
        }
    }

    private void PlayRunSoundWithVariation()
    {
        if (runningSource != null && run != null)
        {
            float randomPitch = basePitch + Random.Range(-pitchVariation, pitchVariation);
            runningSource.pitch = randomPitch;
            runningSource.PlayOneShot(run, masterVolume * runningVolume);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        PlaySFXWithPitch(clip, basePitch);
    }

    public void PlaySFXWithPitch(AudioClip clip, float pitch, float volumeMultiplier = 1f)
    {
        if (SFXSource != null && clip != null)
        {
            float randomPitch = pitch * Random.Range(1 - pitchVariation, 1 + pitchVariation);
            SFXSource.pitch = randomPitch;
            SFXSource.PlayOneShot(clip, masterVolume * sfxVolume * volumeMultiplier);
            SFXSource.pitch = basePitch;
        }
    }

    // Specialized methods with individual volume control
    public void PlayJumpSound()
    {
        PlaySFXWithPitch(jump, 0.6f, jumpVolume);
    }

    public void PlayLightKatanaSound()
    {
        PlaySFXWithPitch(lightKatana, 1.2f, lightKatanaVolume);
    }

    public void PlayHeavyKatanaSound()
    {
        PlaySFXWithPitch(heavyKatana, 0.6f, heavyKatanaVolume);
    }

    public void PlayBlasterSound()
    {
        PlaySFXWithPitch(blaster, 1.0f, blasterVolume);
    }

    public void PlayHurtSound()
    {
        PlaySFXWithPitch(hurt, 1.0f, hurtVolume);
    }

    public void PlayDeathSound()
    {
        PlaySFXWithPitch(die, 0.95f, deathVolume);
    }

    public void PlayRespawnSound()
    {
        PlaySFXWithPitch(respawn, 1.1f, respawnVolume);
    }
}
