using System.Collections;
using System.Collections.Generic;
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
        if(_characterController.IsTargetReached()==true)
        {
            Debug.Log("TargetIsReached");
            _targetPointer.DestroyPoint();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 characterDestination = _mouseConverter.CalculateScreenPointToTarget(_ground);
            _targetPointer.CreatePoint(_targetPointPrefab, characterDestination);

            if (characterDestination != Vector3.zero)
                _characterController.Update(Time.deltaTime, characterDestination);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(mouseWorldPosition.x, 1f, mouseWorldPosition.y), 0.3f);
    }
}
