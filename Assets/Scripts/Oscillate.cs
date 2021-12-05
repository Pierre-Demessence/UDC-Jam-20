using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _magnitude;

    private void Update()
    {
        transform.Translate(_direction.normalized * (Mathf.PingPong(Time.time, 2) - 1) * _magnitude);
    }
}