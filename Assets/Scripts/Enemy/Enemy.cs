using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyParameters _enemyParameters;
     private EnemyMovement _enemyMovement;


    public Action OnFixedUpdate;
    public Action OnUpdate;
    public Action OnPlayerDamaged;

   

    private void Awake()
    {
        OnPlayerDamaged += () => Destroy(this.gameObject);
        Initialize();
    }
    private void Initialize()
    {
        _enemyMovement = new EnemyMovement(this,_enemyParameters.Speed,_enemyParameters.MovementRadius);
    }
    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
    private void Update()
    {
        OnUpdate?.Invoke();
    }
    
}
