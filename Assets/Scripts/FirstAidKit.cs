using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private float _healthToRestore = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICureable>(out ICureable cureable))
        {
            cureable.Cure(_healthToRestore);

            Destroy(gameObject);
        }
    }
}
