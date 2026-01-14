using UnityEngine;

public abstract class Controller
{
    private bool _isEnabled;

    public virtual void Enable() => _isEnabled = true;

    public virtual void Disable() => _isEnabled = false;

    public void Update(float deltaTime, Vector3 direction)
    {
        if (_isEnabled == false)
            return;

        UpdateLogic(deltaTime, direction);
    }

    protected abstract void UpdateLogic(float deltaTime, Vector3 direction);
}
