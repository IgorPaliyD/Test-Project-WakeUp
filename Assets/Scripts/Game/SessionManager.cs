using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.IO;

public class SaveData
{
    public int _userScore = 0;
    public int SavedScore => _userScore;
    public SaveData(int score)
    {
        _userScore = score;
    }
}
public class SessionManager : MonoBehaviour
{
    
    [SerializeField] private Player _player;
    [SerializeField] private PlayerParameters _playerParameters;
    [SerializeField] private Basket _basket;

    [SerializeField] private SessionParameters _session;

    public UnityEvent OnGameStarted;
    public UnityEvent OnGameEnded;

    private SaveData _savedData;

    private void Awake()
    {
        LoadScore();
        
        OnGameStarted.AddListener(ResetGameData);
        OnGameEnded.AddListener(SetHightScore);

        OnGameStarted.AddListener(_session.OnGameStarted.Invoke);
        OnGameEnded.AddListener(_session.OnGameEnded.Invoke);
        _player.OnDeath.AddListener(this.OnGameEnded.Invoke);
        _basket.OnFruitAdded += _session.OnScored.Invoke;
    }
    private void OnEnable()
    {
       
    }
    private void Start()
    {
        OnGameStarted.Invoke();
    }
    private void ResetGameData()
    {
        _playerParameters.ResetHealth();
        _basket.ResetBasket();
    }
    private void SetHightScore()
    {
        int result = 0;
        if (_session.Score > _savedData.SavedScore)
        {
            result = _session.Score;
        }
        else
        {
            result = _savedData.SavedScore;
        }
        _session.OnGameResult.Invoke(result);
        SaveScore();
    }
    private void SaveScore()
    {
        _savedData = new SaveData(_session.HighScore);
        
        string data = JsonUtility.ToJson(_savedData);

        File.WriteAllText(Application.persistentDataPath + "/HighScore.txt", data);
    }
    private void LoadScore()
    {
        if(File.Exists(Application.persistentDataPath + "/HighScore.txt"))
        {
            string save = File.ReadAllText(Application.persistentDataPath + "/HighScore.txt");
            _savedData = JsonUtility.FromJson<SaveData>(save);
            
        }
        else
        {
            _savedData = new SaveData(0);
        }
    }

}
