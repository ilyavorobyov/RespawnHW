using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private float _respawnInterval;

    private Vector3[] _points;
    private Coroutine _createEnemy;
    private bool _is—reating = true;

    private void Start()
    {
        _points = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i).position;
        }

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

        while (_is—reating)
        {
            Instantiate(_enemy, _points[numberOfPoint], Quaternion.identity);
            numberOfPoint++;

            if (numberOfPoint == _points.Length)
            {
                numberOfPoint = 0;
            }

            yield return waitForSeconds;
        }
    }
}