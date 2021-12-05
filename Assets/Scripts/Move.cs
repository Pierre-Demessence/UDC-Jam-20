using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}