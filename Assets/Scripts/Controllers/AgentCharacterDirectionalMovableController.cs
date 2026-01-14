using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentCharacterDirectionalMovableController : Controller
{
    private AgentCharacter _character;
    private float _minDistanceToTarget;
    private float _distanceToTarget;
    private NavMeshPath _pathToTarget = new NavMeshPath();

    public AgentCharacterDirectionalMovableController(
        AgentCharacter character,
        float minDistanceToTarget)
    {
        _character = character;
        _minDistanceToTarget = minDistanceToTarget;
    }

    public bool IsTargetReached() => _distanceToTarget <= _minDistanceToTarget;

    protected override void UpdateLogic(float deltaTime, Vector3 direction)
    {
        Debug.Log(_character.CurrentVelocity);
        _character.SetRotationDirection(_character.CurrentVelocity); // Не устанавливается?

        if (_character.TryGetPath(direction, _pathToTarget))
        {
            _distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

            //if (IsTargetReached(distanceToTarget))
            //    _character.StopMove();

            _character.ResumeMove();
            _character.SetDestination(direction);
            return;
        }

        _character.StopMove();
    }

}
