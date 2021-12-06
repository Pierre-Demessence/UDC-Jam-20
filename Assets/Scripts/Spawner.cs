using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minInterval = 3;
    [SerializeField] private float _maxInterval = 6;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_minInterval);
        while (true)
        {
            Instantiate(_prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(_minInterval, _maxInterval));
        }
    }
}