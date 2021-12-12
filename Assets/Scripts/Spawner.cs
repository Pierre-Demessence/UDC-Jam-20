using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
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
            var prefab = _prefabs[Random.Range(0, _prefabs.Count)];
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(Random.Range(_minInterval, _maxInterval));
        }
    }
}