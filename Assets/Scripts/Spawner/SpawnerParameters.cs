using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Assets/Spawner Parameter")]
public class SpawnerParameters : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnCooldown =1f;
    [SerializeField] private float _minDistanceToPlayer=1f;

    public float SpawnCooldown => _spawnCooldown;
    public GameObject Prefab => _prefab;
    public float MinDistanceToplayer => _minDistanceToPlayer;
}
