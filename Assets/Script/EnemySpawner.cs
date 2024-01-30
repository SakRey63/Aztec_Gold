using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float _timeToSpawn;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _spawnOnStartGame;
    [SerializeField] private GameObject _stonesPrefab;
    [SerializeField] private Transform _stonesPoints;
    [SerializeField] private Transform[] _pointsFish;
    [SerializeField] private GameObject[] _fish;
    [SerializeField] private Transform[] _pointsSharks;
    [SerializeField] private GameObject _shark;

    

    public void SpawnFishes()
    {
        InvokeRepeating(nameof(SpawnFish), time: 5.0f, repeatRate: 10.0f);
        Invoke(nameof(SpawnShark), time: 1.0f);
        Invoke(nameof(SpawnShark), time: 1.0f);
        Invoke(nameof(SpawnShark), time: 1.0f);
    }
    

    public void SpawnShark()
    {
        int index = Random.Range(0, _pointsSharks.Length);
        Instantiate(_shark, _pointsSharks[index].position, _pointsSharks[index].rotation);
    }

    public void SpawnFish()
    {
        int pointIindex = Random.Range(0, _pointsFish.Length);
        int fishIndex = Random.Range(0, _fish.Length);
        
        Instantiate(_fish[fishIndex], _pointsFish[pointIindex].position, _pointsFish[pointIindex].rotation);
    }

    public void Spawn()
    {
        int index = Random.Range(0, _points.Length);
        Instantiate(_enemyPrefab, _points[index].position, _points[index].rotation);
    }

    public void SpawnOnStart()
    {
        Instantiate(_enemyPrefab, _spawnOnStartGame.position, _spawnOnStartGame.rotation);
    }
    
    public void SpawnStones()
    {
        Instantiate(_stonesPrefab, _stonesPoints.position, _stonesPoints.rotation);
    }
    
}
