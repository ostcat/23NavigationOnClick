using UnityEngine;
using UnityEngine.Audio;

public class FirstAidKitView : MonoBehaviour 
{
    private AudioSource _audioSource;
    private AudioClip _explosionSound;
    private AudioMixerGroup _soundsGroup;
    
    public FirstAidKitView(AudioSource audioSource, AudioClip explosionSound, AudioMixerGroup soundsGroup)
    {
        _audioSource = audioSource;
        _explosionSound = explosionSound;
        _soundsGroup = soundsGroup;

        _audioSource.clip = _explosionSound;
        _audioSource.outputAudioMixerGroup = _soundsGroup;
    }

    public void PlayCollectionSound()
    {
        if(_audioSource != null)
        {
            _audioSource.Play();
        }
    }
}
