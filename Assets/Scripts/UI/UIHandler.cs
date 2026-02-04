using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Button _musicToggleButton;
    [SerializeField] private Button _soundsToggleButton;
    [SerializeField] private AudioMixer _audioMixer;

    private AudioHandler _audioHandler;

    private void Awake()
    {
        _audioHandler = new AudioHandler(_audioMixer);

        _musicToggleButton.onClick.AddListener(ToggleMusic);
        _soundsToggleButton.onClick.AddListener(ToggleSounds);
    }

    private void ToggleMusic() => _audioHandler.ToggleMusic();

    private void ToggleSounds() => _audioHandler.ToggleSounds();

}
