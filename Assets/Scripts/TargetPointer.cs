using UnityEngine;

public class TargetPointer
{
    private TargetPoint _point;

    public void CreatePoint(TargetPoint pointPrefab, Vector3 point)
    {
        _point = Object.Instantiate(pointPrefab, point, Quaternion.identity);
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
