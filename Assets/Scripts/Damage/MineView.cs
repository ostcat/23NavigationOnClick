using UnityEngine;
using UnityEngine.Audio;

public class MineView : MonoBehaviour
{
    [SerializeField] private Mine _mine;

    [SerializeField] private ParticleSystem _explosionEffectPrefab;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioMixerGroup _soundsGroup;

    private void Update()
    {
        if (_mine.IsExploding)
            ExecuteEffect();
    }

    private void ExecuteEffect()
    {
        GameObject explosionGameObject = Instantiate(_explosionEffectPrefab.gameObject, transform.position, Quaternion.identity);
        ParticleSystem explosionEffect = explosionGameObject.GetComponent<ParticleSystem>();
        explosionEffect.Play();

        AudioSource audioOnEffect = explosionGameObject.AddComponent<AudioSource>();
        audioOnEffect.clip = _explosionSound;
        audioOnEffect.outputAudioMixerGroup = _soundsGroup;
        audioOnEffect.PlayOneShot(_explosionSound);

        explosionEffect.Play();

        Destroy(gameObject);

        float duration = explosionEffect.main.duration + explosionEffect.main.startLifetime.constantMax;
        Object.Destroy(explosionGameObject, duration);
    }
}
