using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Game Settings/Session Parameters")]
public class SessionParameters : ScriptableObject
{
    private int _highScore = 0;
    private int _score = 0;
    public int HighScore => _highScore;
    public int Score => _score;

    [HideInInspector]
    public UnityEvent OnGameStarted;
    [HideInInspector]
    public UnityEvent OnGameEnded;
    [HideInInspector]
    public UnityEvent<int> OnScored;
    [HideInInspector]
    public UnityEvent<int> OnGameResult;
   
    private void OnEnable()
    {
        OnScored.AddListener(SetScore);
        OnGameResult.AddListener(SetHightScore);
    }
    private void SetHightScore(int score)
    {
        _highScore = score;        
    }
    private void SetScore(int score)
    {
        _score = score;
    }
}

