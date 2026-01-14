using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointer
{
    private TargetPoint _point;

    public void CreatePoint(TargetPoint pointPrefab, Vector3 origin, Vector3 direction, LayerMask layerMask)
    {
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask.value))
        {
            _point = Object.Instantiate(pointPrefab, hit.point, Quaternion.identity);
        }
    }

    public void DestroyPoint()
    {
        Object.Destroy(_point);
    }
}
