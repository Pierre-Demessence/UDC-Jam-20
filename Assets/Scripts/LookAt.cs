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
        var newPos  = (_target.position - transform.parent.position).normalized * _radius;
        transform.localPosition = new Vector3(newPos.x, newPos.y, transform.localPosition.z);

        var size = Mathf.Lerp(_maxSize, _minSize, Mathf.Abs(transform.position.x - _target.position.x)  / _initialDistance);
        transform.localScale = Vector3.one * size;
    }
}