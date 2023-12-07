using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;

    public void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.Init(_target);
    }
}