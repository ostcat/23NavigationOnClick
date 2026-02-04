using System.Collections;
using UnityEngine;

public class AidKitSpawner
{
    private MonoBehaviour _coroutineRunner;
    private Coroutine _process;

    private FirstAidKit _aidKitPrefab;
    private Transform _target;
    private float _radius;
    private float _timeForSpawn;

    public AidKitSpawner(MonoBehaviour coroutineRunner, FirstAidKit aidKitPrebab, Transform target, float radius, float timeForSpawn)
    {
        _coroutineRunner = coroutineRunner;
        _aidKitPrefab = aidKitPrebab;
        _target = target;
        _radius = radius;
        _timeForSpawn = timeForSpawn;
    }

    public bool InProcess()
    {
        if (_process == null)
            return false;

        return true;
    }

    public void Toggle()
    {
        if (_process != null)
        {
            StopProcess();
        }
        else
        {
            StartProcess();
        }
    }

    private void StartProcess()
    {
        _process = _coroutineRunner.StartCoroutine(Process());
    }

    private void StopProcess()
    {
            _coroutineRunner.StopCoroutine(_process);
            _process = null;
    }

    private IEnumerator Process()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeForSpawn);
            Spawn();
        }
    }

    private void Spawn()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        Vector3 spawnPosition = _target.position + direction * _radius;

        Object.Instantiate(_aidKitPrefab, spawnPosition, Quaternion.identity);
    }
}
