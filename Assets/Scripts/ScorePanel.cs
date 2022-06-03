using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Background _background;

    private int _scoreValue = 0;
    private readonly int _startValue = 0;
    
    private void Start()
    {
        _score.text = _startValue.ToString();
    }

    private void OnEnable()
    {
        _background.Bombed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _background.Bombed -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _scoreValue += 1;
        _score.text = _scoreValue.ToString();
    }
}
