using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class Player : MonoBehaviour
{
    [SerializeField] private PlayerParameters _playerParameters;
    [SerializeField] private Basket _basket;
    [SerializeField] private Camera _mainCamera;

    [Header("Interaction Layers")]
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private LayerMask _fruitLayer;

    [Header("Player Events")]
    public UnityEvent OnCollected;
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath;

    public LayerMask EnemyLayer => _enemyLayer;
    public LayerMask FruitLayer => _fruitLayer;
    
    public Action OnUpdate;
    public Action OnFixedUpdate;

    private PlayerMovement _movement;
    private FruitCollector _fruitCollector;
    private PlayerDamageTrigger _damageTrigger;
   
    private void Initialize()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }

        AddActions();

        _movement = new PlayerMovement(this, _playerParameters.Speed,_mainCamera);
        _fruitCollector = new FruitCollector(this,_basket.OnFruitCollected,_playerParameters.HandLength);
        _damageTrigger = new PlayerDamageTrigger(this, _playerParameters.OnGetDamage, 1f);

        
    }
    private void AddActions()
    {
        _playerParameters.OnGetDamage += OnDamaged.Invoke;
        _playerParameters.OnDamageApplied += CheckPlayerAlive;
        _basket.OnFruitCollected += OnCollected.Invoke;
    }
    //private void RemoveActions()
    //{
       
    //    _basket.OnFruitCollected -= OnCollect.Invoke;
    //}
    private void Awake()
    {
        Initialize();
    }
    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
    private void Update()
    {
        OnUpdate?.Invoke();
    }
    private void CheckPlayerAlive(int health)
    {
        if (health <= 0)
        {
            OnDeath.Invoke();
        }
    }
    
}
