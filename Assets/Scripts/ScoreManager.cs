using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private float _scoreMultiplier = 1;
    private float _score = 0;
    public float Score
    {
        get => _score;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score += Time.deltaTime * _scoreMultiplier;
        _scoreText.text = "Score : " + _score.ToString("F0");
    }
}
