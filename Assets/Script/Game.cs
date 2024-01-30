using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _ObjectToInstantiate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ForthBlockOfStone _forthBlockOfStone;
    [SerializeField] private MovingToTheRight _movingToTheRight;
    [SerializeField] private MovingToTheLeft _movingToTheLeft;
    [SerializeField] private Fall _cubes;
    [SerializeField] private SupportOff _support;
    [SerializeField] private BridgeIsDisappearing _bridgeIsDisappearing;
    [SerializeField] private TurningGrid _turningGrid;
    [SerializeField] private EnemySpawner _stoneSpawn;
    [SerializeField] private TMP_Text _skeletonPoints;
    [SerializeField] private TMP_Text _skeletonScores;
    [SerializeField] private EnemySpawner _spawnFishes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skeleton block = FindObjectOfType<Skeleton>();
            if (block != null)
            {
                Destroy(block.gameObject);
            }   
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var go = Instantiate(_ObjectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
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
}
