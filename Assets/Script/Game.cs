using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _ObjectToInstantiate;
    [SerializeField] private Transform _spawnPoint;
    
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
            Instantiate(_ObjectToInstantiate, _spawnPoint.position, _spawnPoint.rotation);
        }
        
    }
}
