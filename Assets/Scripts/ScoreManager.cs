using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _scoreMultiplier = 1;
    public float Score { get; private set; }

    private void Update()
    {
        Score += Time.deltaTime * _scoreMultiplier;
        _scoreText.text = "Score : " + Score.ToString("F0");
    }
}