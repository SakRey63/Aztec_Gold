using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;
using PointerType = UnityEngine.UIElements.PointerType;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject _ork;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _spawnOnStartGame;
    [SerializeField] private GameObject _stonesPrefab;
    [SerializeField] private Transform _stonesPoints;
    [SerializeField] private Transform[] _spawnFish;
    [SerializeField] private Fish[] _fish;
    [SerializeField] private Transform[] _spawnSharks;
    [SerializeField] private Shark _shark;
    [SerializeField] private Transform[] _pointsFishes;
    [SerializeField] private int _numberOfSharks;
    [SerializeField] private GameObject _foodFish;

    [SerializeField] private int _timeFoodsStart;
    [SerializeField] private int _timeFoodsRepeat;

    private GameObject _go;
    public void SpawnFishes()
    {
        InvokeRepeating(nameof(SpawnFish), time: 10.0f, repeatRate: 15.0f);
        InvokeRepeating(nameof(SpawnFoodsFishes), _timeFoodsStart, repeatRate: _timeFoodsRepeat);

        for (int i = 0; i < _numberOfSharks; i++)
        {
            Invoke(nameof(SpawnShark), time: 1.0f);
        }
        
    }
    
    public void SpawnShark()
    {
        int index = Random.Range(0, _spawnSharks.Length);
       var go = Instantiate(_shark, _spawnSharks[index].position, _spawnSharks[index].rotation);


    }

    public void SpawnFish()
    {
        var pointIndex = Random.Range(0, _spawnFish.Length);
        var fishIndex = Random.Range(0, _fish.Length);

        var go = Instantiate(_fish[fishIndex], _spawnFish[pointIndex].position, _spawnFish[pointIndex].rotation);
        
        if (_foodFish != null)
        {
            go.GetComponent<Fish>().SetTarget(_foodFish.transform);
        }

    }



    public void Spawn()
    {
        int index = Random.Range(0, _points.Length);
        Instantiate(_ork, _points[index].position, _points[index].rotation);
        
    }

    public void SpawnOnStart()
    {
        Instantiate(_ork, _spawnOnStartGame.position, _spawnOnStartGame.rotation);
    }
    
    public void SpawnStones()
    {
        Instantiate(_stonesPrefab, _stonesPoints.position, _stonesPoints.rotation);
    }

    public void SpawnFoodsFishes()
    {
        int indexPoint = Random.Range(0, _pointsFishes.Length);
        var go = Instantiate(_foodFish, _pointsFishes[indexPoint].position, _pointsFishes[indexPoint].rotation);
        
    }
    
}
