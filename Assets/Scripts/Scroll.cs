using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Scroll : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Renderer _renderer;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(Time.deltaTime * _speed * _scoreManager.ScoreSpeedModifier, 0f);
    }
}