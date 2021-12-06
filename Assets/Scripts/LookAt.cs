using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _radius;

    private void Update()
    {
        var lookDir = (_target.position - transform.parent.position).normalized;
        transform.localPosition = lookDir * _radius;
    }
}