using UnityEngine;
using UnityEngine.AI;

public class AgentCharacterDirectionalMovableController : Controller
{
    private AgentCharacter _character;
    private float _minDistanceToTarget;
    private float _distanceToTarget;
    private Vector3 _destination;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    public Vector3 Destination => _destination;

    public AgentCharacterDirectionalMovableController(
        AgentCharacter character,
        float minDistanceToTarget)
    {
        _character = character;
        _minDistanceToTarget = minDistanceToTarget;
    }

    public bool IsTargetReached() => _distanceToTarget <= _minDistanceToTarget;

    public void SetDestination(Vector3 destination) => _destination = destination; 

    protected override void UpdateLogic(float deltaTime)
    {
        _character.SetRotationDirection(_character.CurrentVelocity);

        if (_character.TryGetPath(_destination, _pathToTarget))
        {
            _distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

            _character.ResumeMove();
            _character.SetDestination(_destination);
            return;
        }

        _character.StopMove();
    }
}
