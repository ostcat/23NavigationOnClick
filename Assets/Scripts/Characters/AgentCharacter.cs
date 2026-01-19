using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IDamageable
{
    private NavMeshAgent _agent;

    private AgentMover _mover;
    private DirectionalRotator _rotator;
    private Health _health;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Animator _animator;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);
        _health = new Health(_maxHealth, _animator);
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 position) => _mover.SetDestination(position);

    public void StopMove() => _mover.Stop();

    public void ResumeMove() => _mover.Resume();

    public void TakeDamage(float damage) => _health.TakeDamage(damage);

    public bool IsInjured() => _health.IsInjured();

    public bool IsDead() => _health.IsDead();

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);
}
