using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game Assets/Player Parameters")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] private int _defaultHealth;

    private int _health;
    [SerializeField] private float _baseSpeed;

    //длина руки = радиус колайдера для сбора фруктов
    [SerializeField] private float _handLength;

    public Action<int> OnDamageApplied;
    public Action OnGetDamage;

    public delegate void Reset();
    public Reset ResetHealth;

    public int Health => _health;
    public float Speed => _baseSpeed;
    public float HandLength => _handLength;

    private void OnEnable()
    {
        ResetHealth += ResetCurrentHealth;
        OnGetDamage += DecreaseHealth;
    }
    private void OnDisable()
    {
        OnGetDamage -= DecreaseHealth;
    }
    private void DecreaseHealth()
    {
        if (_health > 0)
        {
            _health--;
            OnDamageApplied.Invoke(Health);
            return;
        }
    }
    private void ResetCurrentHealth()
    {
        _health = _defaultHealth;
    }
}
