using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _radius;

    [SerializeField] private float _minSize = 0.5f;
    [SerializeField] private float _maxSize = 1.5f;

    private float _initialDistance;

    private void Start()
    {
        _initialDistance = Mathf.Abs(transform.position.x - _target.position.x);
    }

    private void Update()
    {
        var lookDir = (_target.position - transform.parent.position).normalized;
        transform.localPosition = lookDir * _radius;

        var size = Mathf.Lerp(_maxSize, _minSize, Mathf.Abs(transform.position.x - _target.position.x)  / _initialDistance);
        transform.localScale = Vector3.one * size;
    }
}