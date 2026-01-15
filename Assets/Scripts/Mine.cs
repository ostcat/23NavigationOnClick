using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _damage;
    [SerializeField] private AgentCharacter _character;
    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    private void Update()
    {
        if(IsInExplosionArea())
            Explode();
    }

    public void Explode()
    {
        _character.TakeDamage(_damage);
        ParticleSystem explosionEffect = Object.Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
        explosionEffect.Play();

        Destroy(gameObject);

        float duration = explosionEffect.main.duration + explosionEffect.main.startLifetime.constantMax;
        Object.Destroy(explosionEffect.gameObject, duration);
    }

    
    private bool IsInExplosionArea() => (_character.transform.position - transform.position).magnitude <= _radius;
}
