using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private TargetPoint _targetPointPrefab;
    [SerializeField] private Transform _ground;
    [SerializeField] private FirstAidKit _aidKitPrefab;
    [SerializeField] private float _timeForAidKitToSpawn = 3;
    [SerializeField] private float _radiusForAidKitSpawn = 3;

    private AgentCharacterDirectionalMovableController _characterController;
    private MouseToWorldPositionConverter _mouseConverter;
    private TargetPointer _targetPointer;
    private AidKitSpawner _aidSpawner;

    private void Awake()
    {
        _mouseConverter = new MouseToWorldPositionConverter();

        _characterController = new AgentCharacterDirectionalMovableController(_character, 2);
        _characterController.Enable();

        _targetPointer = new TargetPointer(_characterController);
        _aidSpawner = new AidKitSpawner(this, _aidKitPrefab, _character.transform, _radiusForAidKitSpawn, _timeForAidKitToSpawn);
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

            _characterController.SetDestination(characterDestination);
            _targetPointer.CreatePoint(_targetPointPrefab);   
        }

        if (Input.GetKeyDown(KeyCode.F))
            _aidSpawner.Toggle();

        _characterController.Update(Time.deltaTime);
    }

}
