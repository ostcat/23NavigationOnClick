using UnityEngine;

public class AgentCharacterView : MonoBehaviour
{
    private const int BaseLayerIndex = 0;
    private const int InjuredLayerIndex = 1;
    private const float TurnOnLayerWeight = 1.0f;
    private const float TurnOffLayerWeight = 0f;
    private const float MinVelocityToMove = 0.05f;

    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsDeadKey = Animator.StringToHash("IsDead");
    private readonly int InJumpProcessKey = Animator.StringToHash("InJumpProcess");

    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    private void Update()
    {
        if (_character.IsDead())
        {
            _animator.SetBool(IsDeadKey, true);
        }

        _animator.SetBool(InJumpProcessKey, _character.InJumpProcess);

        if (_character.IsInjured())
        {
            _animator.SetLayerWeight(BaseLayerIndex, TurnOffLayerWeight);
            _animator.SetLayerWeight(InjuredLayerIndex, TurnOnLayerWeight);
        }
        else
        {
            _animator.SetLayerWeight(BaseLayerIndex, TurnOnLayerWeight);
            _animator.SetLayerWeight(InjuredLayerIndex, TurnOffLayerWeight);
        }

        if (_character.CurrentVelocity.magnitude >= MinVelocityToMove)
            StartRunning();
        else
            StopRunning();
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }
}
