using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FirstAidKitView
{
    private AudioSource _audioSource;
    private AudioClip _explosionSound;
    private AudioMixerGroup _soundsGroup;
    
    public void Initialize(AudioSource audioSource, AudioClip explosionSound, AudioMixerGroup soundsGroup)
    {
        _audioSource = audioSource;
        _explosionSound = explosionSound;
        _soundsGroup = soundsGroup;
    }
    public void PlayCollectionSound()
    {

    }
}
