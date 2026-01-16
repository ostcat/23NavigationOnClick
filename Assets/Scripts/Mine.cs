using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _damage;
    [SerializeField] private AgentCharacter _character;
    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    private float _timer;
    private float _timerDuration = 2f;
    private bool _isCountingDown;

    private void Awake()
    {
        _timer = _timerDuration;
    }

    private void Update()
    {
        if (IsInExplosionArea())
            _isCountingDown = true; 

        if(_isCountingDown == true)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
                Explode();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    public void Explode()
    {
        if (IsInExplosionArea())
            _character.TakeDamage(_damage);

        ParticleSystem explosionEffect = Object.Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
        explosionEffect.Play();

        Destroy(gameObject);

        float duration = explosionEffect.main.duration + explosionEffect.main.startLifetime.constantMax;
        Object.Destroy(explosionEffect.gameObject, duration);
    }

    private bool IsInExplosionArea() => (_character.transform.position - transform.position).magnitude <= _radius;
    
}
