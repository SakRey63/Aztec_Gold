using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _ObjectToInstantiate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _camera;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ForthBlockOfStone _forthBlockOfStone;
    [SerializeField] private MovingToTheRight _movingToTheRight;
    [SerializeField] private MovingToTheLeft _movingToTheLeft;
    [SerializeField] private SupportOff _support;
    [SerializeField] private BridgeIsDisappearing _bridgeIsDisappearing;
    [SerializeField] private TurningGrid _turningGrid;
    [SerializeField] private EnemySpawner _stoneSpawn;
    [SerializeField] private EnemySpawner _spawnFishes;
    [SerializeField] private Ork _ork;
    
    

    private readonly List<GameObject> _objectsToDestroy = new();
    private void Awake()
    {
        GameObject go = Instantiate(_ObjectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
        var component = go.GetComponent<Pathfinder>();
        if (component != null)
        {
            component.SetCamera(_camera);
            component.OpenRight(_movingToTheRight);
            component.OpenLeft(_movingToTheLeft);
            component.SpawnFish(_spawnFishes);
        }
        Register(go);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Pathfinder block = FindObjectOfType<Pathfinder>();
            if (block != null)
            {
                Destroy(block.gameObject);
            }   
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var go = Instantiate(_ObjectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
            _ork.SetTarget(go.transform);
            
            var component = go.GetComponent<Skeleton>();
            if (component != null)
            {
                component.SetSpawner(_enemySpawner);
                component.SetRun(_forthBlockOfStone);
                component.OpenRight(_movingToTheRight);
                component.OpenLeft(_movingToTheLeft);
                component.SupportOn(_support);
                component.SetBridgeOf(_bridgeIsDisappearing);
                component.Turning(_turningGrid);
                component.Stones(_stoneSpawn);
                component.SpawnFish(_spawnFishes);
            }
        }
        
    }

    private void Register(GameObject objectToDestroy)
    {
        _objectsToDestroy.Add(objectToDestroy);
    }
}
