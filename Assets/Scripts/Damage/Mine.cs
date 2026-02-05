using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private Timer _timer;
    private float _timerDuration = 2f;
    private bool _isActivated;

    public bool IsExploding { get; private set; }

    private void Awake()
    {
        _timer = new Timer(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated == false && other.GetComponent<IDamageable>() != null) 
        {
            _isActivated = true;
            _timer.StartProcess(_timerDuration);
        }
    }

    private void Update()
    {
        if (_isActivated && _timer.InProcess(out float elapsedTime) == false)
        {
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
