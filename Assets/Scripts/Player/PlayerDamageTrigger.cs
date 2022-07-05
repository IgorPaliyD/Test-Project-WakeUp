using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerDamageTrigger
{
    private event Action _playerDamageAction;
    private Player _player;
    private float _circleRadius;
    public PlayerDamageTrigger(Player player, Action playerAction, float radius)
    {
        _player = player;
        _playerDamageAction = playerAction;
        _circleRadius = radius;
        Initialize();
    }
    private void Initialize()
    {
        _player.OnUpdate += TryReceiveDamage;
    }
    private void TryReceiveDamage()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_player.transform.position, _circleRadius, _player.EnemyLayer); ;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].TryGetComponent<Enemy>(out var enemy))
            {
                _playerDamageAction?.Invoke();
                enemy.OnPlayerDamaged.Invoke();
            }
        }
    }

}
