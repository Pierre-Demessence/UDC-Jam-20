using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Scroll : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(Time.time * _speed, 0f);
    }
}