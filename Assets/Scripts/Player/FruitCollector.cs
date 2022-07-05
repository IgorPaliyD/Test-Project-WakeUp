using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FruitCollector
{
    private event Action _playerCollectAction;
    private Player _player;
    private float _circleRadius;
    public FruitCollector(Player player,Action playerAction,float radius)
    {
        _player = player;
        _playerCollectAction = playerAction;
        _circleRadius = radius;
        Initialize();
    }
    private void Initialize()
    {
        _player.OnUpdate += TryCollectFruit;
        
    }
   private void TryCollectFruit()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_player.transform.position, _circleRadius, _player.FruitLayer); ; 
        for(int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].TryGetComponent<Fruit>(out var fruit))
            {
                _playerCollectAction?.Invoke();
                fruit.OnCollected.Invoke();
            }
        }
    }
    
}
