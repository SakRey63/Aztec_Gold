using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float _timeToSpawn;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _Points;
    [SerializeField] private Transform _spawnOnStartGame;
    
    
    // Start is called before the first frame update
   

    public void Spawn()
    {
        int index = Random.Range(0, _Points.Length);
        Instantiate(_enemyPrefab, _Points[index].position, _Points[index].rotation);
    }

    public void SpawnOnStart()
    {
        Instantiate(_enemyPrefab, _spawnOnStartGame.position, _spawnOnStartGame.rotation);
    }
}
