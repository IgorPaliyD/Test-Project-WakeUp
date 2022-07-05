using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;


//хотел разделить реализацию и не использовать Movobehaviour здесь тоже,
//но не смог ввиду того что не знаю как использовать Instantiate без участи€ MonoBeh и не использу€ public функции
public class Spawner:MonoBehaviour
{
    [SerializeField] private SpawnerParameters _parameters;
    [SerializeField] private SessionParameters _session;
    
    [SerializeField] private CornerName[] _corners= new CornerName[2];
    
    [SerializeField] private Transform _playerTransform;


    private Vector2 _currentSpawnPoint;
    private Coroutine _spawnCoroutine;
    private Vector2 _playerCoordinates = new Vector2(0f,0f);
    private List<Vector3> _boundsAnchors;
    

    public Action OnUpdate;
    public Action OnFixedUpdate;
    //private Action OnSpawnPerform;

    public UnityEvent OnStartSpawn;
    public UnityEvent OnStopSpawn;
    public UnityEvent OnSpawn;

    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        if (_playerTransform)
        {
            _playerCoordinates = _playerTransform.position;
        }
        _boundsAnchors = new List<Vector3>();
        
        
        this.OnStartSpawn.AddListener(StartSpawn);
        this.OnStopSpawn.AddListener(StopSpawn);

        _session.OnGameStarted.AddListener(this.OnStartSpawn.Invoke);
        _session.OnGameEnded.AddListener(this.OnStopSpawn.Invoke);

    }
    private void Start()
    {
        foreach (var a in _corners)
        {
            if (CameraBoundsToWorld.WorldPositionCorners.ContainsKey(a))
            {
                _boundsAnchors.Add(CameraBoundsToWorld.WorldPositionCorners[a]);
            }
        }
       
    }

    private void Spawn() 
    {
            _currentSpawnPoint = GetRandomSpawnPosition();
            Instantiate(_parameters.Prefab, new Vector3(_currentSpawnPoint.x, _currentSpawnPoint.y, 0), Quaternion.identity, this.transform);
            this.OnSpawn.Invoke();  
    }
    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 firstAnchor = new Vector2(_boundsAnchors[0].x, _boundsAnchors[0].y);
        Vector2 secondAnchor = new Vector2(_boundsAnchors[1].x, _boundsAnchors[1].y);

        var xPosition = Random.Range(firstAnchor.x,secondAnchor.x);
        var yPosition = Random.Range(firstAnchor.y, secondAnchor.y);
        if(IsPlayerSpawnPosition(new Vector2(xPosition, yPosition)))
        {   
            return GetRandomSpawnPosition();
        }
        
        return new Vector2(xPosition,yPosition);  
    }
    private bool IsPlayerSpawnPosition(Vector2 position)
    { 
        return Vector2.Distance(position,_playerCoordinates) < _parameters.MinDistanceToplayer ? true : false;
    }
    private IEnumerator SpawnPerTime(float time)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(time);
            Spawn();
        }
    }
    private void StartSpawn()
    {
        _spawnCoroutine = StartCoroutine(SpawnPerTime(_parameters.SpawnCooldown));
    }
    private void StopSpawn()
    {
        StopCoroutine(_spawnCoroutine);
    } 
}
