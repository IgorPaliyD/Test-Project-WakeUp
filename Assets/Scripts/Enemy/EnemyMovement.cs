using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement
{
    private float _baseSpeed;
    private Enemy _enemy;
    private float _movementRadius;
    private Vector2 _targetPosition;

    public EnemyMovement(Enemy enemy, float speed,float movementRadius)
    {
        _baseSpeed = speed;
        _enemy = enemy;
        _movementRadius = movementRadius;
        Initialize();
    }

    private void Initialize()
    {
        _enemy.OnUpdate += FindTargetPosition;
        _enemy.OnFixedUpdate += MoveOnTargetPosition;
    }
    private Vector2 GetTargetPosition()
    {
        float randomX = Random.Range(_enemy.transform.position.x-_movementRadius, _enemy.transform.position.x + _movementRadius);
        float randomY = Random.Range(_enemy.transform.position.y-_movementRadius, _enemy.transform.position.y + _movementRadius);
        Vector2 randomTargetPosition = new Vector2(randomX,randomY);
        return randomTargetPosition;
    }
    private void FindTargetPosition()
    { 
            _targetPosition = GetTargetPosition();    
    }
    private void MoveOnTargetPosition()
    {
        if (_targetPosition != Vector2.zero)
        {
            _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position,_targetPosition,Time.deltaTime*_baseSpeed);
        }
    }
   
}
