using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler
{
    private const float OnVolumeValue = 0;
    private const float OffVolumeValue = -80;
    private const string MusicKey = "MusicVolume";
    private const string SoundsKey = "SoundsVolume";

    private AudioMixer _audioMixer;

    public AudioHandler(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public bool IsMusicOn => IsVolumeOn(MusicKey);
    public bool IsSoundsOn => IsVolumeOn(SoundsKey);

    public void ToggleMusic()
    {
        if (IsMusicOn)
            OffValue(MusicKey);
        else
            OnValue(MusicKey);
    }

    public void ToggleSounds()
    {
        if (IsSoundsOn)
            OffValue(SoundsKey);
        else
            OnValue(SoundsKey);
    }

    private bool IsVolumeOn(string key)
=> _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.01f;

    private void OnValue(string key) => _audioMixer.SetFloat(key, OnVolumeValue);

    private void OffValue(string key) => _audioMixer.SetFloat(key, OffVolumeValue);
}
