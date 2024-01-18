using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float _timeToSpawn;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _Points;

    private float _carentTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        _carentTimer -= Time.deltaTime;

        if (_carentTimer <= 0.0f)
        {
            int index = Random.Range(0, _Points.Length);
            Instantiate(_enemyPrefab, _Points[index].position, _Points[index].rotation);
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        _carentTimer = _timeToSpawn;
    }
}
