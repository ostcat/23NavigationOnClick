using UnityEngine;

public class MouseToWorldPositionConverter
{
    public Ray Ray { get; private set; }

    public Vector3 CalculateScreenPointToTarget(Transform groundLevel)
    {
        Vector3 targetPosition = Vector3.zero;

        Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(Ray, out hit))
            return hit.point;

        return targetPosition;
    }
}
