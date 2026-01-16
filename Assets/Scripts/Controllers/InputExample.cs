using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private TargetPoint _targetPointPrefab;
    [SerializeField] private Transform _ground;

    private AgentCharacterDirectionalMovableController _characterController;
    private MouseToWorldPositionConverter _mouseConverter;
    private TargetPointer _targetPointer;

    private void Awake()
    {
        _mouseConverter = new MouseToWorldPositionConverter();
        _targetPointer = new TargetPointer();

        _characterController = new AgentCharacterDirectionalMovableController(_character, 2);
        _characterController.Enable();
    }

    private void Update()
    {
        if (_characterController.IsTargetReached() == true)
        {
            _targetPointer.DestroyPoint();
        }

        if (_character.IsDead())
        {
            _targetPointer.DestroyPoint();
            _characterController.Disable();
            return;
        }    

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 characterDestination = _mouseConverter.CalculateScreenPointToTarget(_ground);
            _targetPointer.CreatePoint(_targetPointPrefab, characterDestination);
            _characterController.SetDestination(characterDestination);
                
        }

        _characterController.Update(Time.deltaTime);
    }
}
