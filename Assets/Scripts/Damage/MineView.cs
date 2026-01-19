using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private Mine _mine;

    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    private void Update()
    {
        if (_mine.IsExploding)
            ExecuteEffect();
    }

    private void ExecuteEffect()
    {
        ParticleSystem explosionEffect = Object.Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
        explosionEffect.Play();

        Destroy(gameObject);

        float duration = explosionEffect.main.duration + explosionEffect.main.startLifetime.constantMax;
        Object.Destroy(explosionEffect.gameObject, duration);
    }
}
