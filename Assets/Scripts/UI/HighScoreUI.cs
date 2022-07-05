using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScoredText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private SessionParameters _session;

    private void Awake()
    {
        _session.OnGameEnded.AddListener(SetScoreText);
    }
    private void OnDisable()
    {
       _session.OnGameEnded.RemoveListener(SetScoreText);
    }
    private void SetScoreText()
    {

        _highScoreText.text = "High Score: " + _session.HighScore;
        _currentScoredText.text = "Scored: " + _session.Score;
    }
}
