using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseToWorldPositionConverter
{
    public Ray Ray {  get; private set; }

    public Vector3 CalculateScreenPointToTarget(Transform groundLevel)
    {
        Vector3 targetPosition = Vector3.zero;

        Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       float fixedY = groundLevel.position.y;

        Plane plane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(Ray, out float distance))
            targetPosition = Ray.GetPoint(distance);

        return targetPosition;
    }
}
