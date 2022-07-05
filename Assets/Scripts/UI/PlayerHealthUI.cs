using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerParameters _playerParams;
    [SerializeField] private SessionParameters _session;
    [SerializeField] private GameObject[] _healthSprites;

    
    private void OnEnable()
    {
        _session.OnGameStarted.AddListener(ResetHP);
        _playerParams.OnGetDamage += DecreaseHP;
        
    }
    private void DecreaseHP()
    {
        _healthSprites[_playerParams.Health].SetActive(false);
    }
    private void ResetHP()
    {
        foreach (var a in _healthSprites) { a.SetActive(true); };
    }
    private void OnDisable()
    {
        _session.OnGameStarted.RemoveListener(ResetHP);
        _playerParams.OnGetDamage -= DecreaseHP;
    }

}
