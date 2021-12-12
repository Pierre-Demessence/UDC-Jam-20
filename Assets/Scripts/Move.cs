using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed = 5f;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime * _scoreManager.ScoreSpeedModifier);
    }
}