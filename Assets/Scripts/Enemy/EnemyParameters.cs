using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Assets/Enemy Parameters")]
public class EnemyParameters : ScriptableObject
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _movementRadius;
    public float Speed { get => _baseSpeed; private set => _baseSpeed = value; }
    public float MovementRadius => _movementRadius;
}
