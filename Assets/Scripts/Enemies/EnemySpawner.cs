using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _respawnInterval;
    [SerializeField] private SpawnPoint[] _points;

    private Coroutine _createEnemy;
    private bool _isCreating = true;

    private void Start()
    {
        StopCreateEnemy();
        _createEnemy = StartCoroutine(CreateEnemy());
    }

    private void OnDestroy()
    {
        StopCreateEnemy();
    }

    private void StopCreateEnemy()
    {
        if (_createEnemy != null)
            StopCoroutine(_createEnemy);
    }

    private IEnumerator CreateEnemy()
    {
        int numberOfPoint = 0;
        var waitForSeconds = new WaitForSeconds(_respawnInterval);

        while (_isCreating)
        {
            _points[numberOfPoint].CreateEnemy();
            numberOfPoint++;

            if (numberOfPoint == _points.Length)
            {
                numberOfPoint = 0;
            }

            yield return waitForSeconds;
        }
    }
}