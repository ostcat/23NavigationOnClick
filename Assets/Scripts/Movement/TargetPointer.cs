using UnityEngine;

public class TargetPointer
{
    private AgentCharacterDirectionalMovableController _controller;
    private TargetPoint _point;

    public TargetPointer(AgentCharacterDirectionalMovableController controller)
    {
        _controller = controller;
    }

    public void CreatePoint(TargetPoint pointPrefab)
    {
        _point = Object.Instantiate(pointPrefab, _controller.Destination, Quaternion.identity);
    }

    public void DestroyPoint()
    {
        if (_point != null)
        {
            Object.Destroy(_point.gameObject);
            _point = null;
        }
    }
}
