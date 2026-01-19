using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private float _timer;
    private float _timerDuration = 2f;
    private bool _isCountingDown;

    public bool IsExploding { get; private set; }

    private void Awake()
    {
        _timer = _timerDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            _isCountingDown = true;
        }
    }

    private void Update()
    {
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
        IsExploding = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable target))
                target.TakeDamage(_damage);
        }
    } 
}
