using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime);
    }
}