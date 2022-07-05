using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SessionParameters _session;

    private void Awake()
    {
        _session.OnScored.AddListener(SetScoreText);
    }
    private void OnDisable()
    {
        _session.OnScored.RemoveListener(SetScoreText);
    }
    private void SetScoreText(int score)
    {

        _text.text = "You Scored: " + score;
    }
}
