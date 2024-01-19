using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour

{
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;
    
    private EnemySpawner _enemySpawner;
    void Update()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * _movementSpeed));
        transform.Rotate(Vector3.up * _rotateSpeed * Input.GetAxis("Horizontal"));
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Skeleton collision enter {other.gameObject.name}");
        Ork component = other.gameObject.GetComponent<Ork>();
        if (component != null)
        {
            Destroy(other.gameObject);
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _enemySpawner.Spavn();
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Skeleton trigger exit {other.gameObject.name}");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Skeleton trigger stay {other.gameObject.name}");
    }
    public void SetSpawner(EnemySpawner spawner)
         {
             _enemySpawner = spawner;
         }
}
