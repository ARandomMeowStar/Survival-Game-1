using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioObject : MonoBehaviour
{
    public AudioClip Clip => curClip;
    private AudioClip curClip;
    private AudioSource audioSource;
    private bool canPlayMultipleSounds;
    public void Setup(AudioClip clip, bool canPlayMultSounds)
    {
        audioSource = GetComponent<AudioSource>();
        curClip = clip;
        canPlayMultipleSounds = canPlayMultSounds;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        if (audioSource.isPlaying && !canPlayMultipleSounds)
            return;

        audioSource.Play();
    }
    public void PauseSound()
    {
       if(!audioSource.isPlaying)
            return;
            
        audioSource.Pause();
    }
}
