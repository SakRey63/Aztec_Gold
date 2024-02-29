using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    
    private Transform _foodFish;
    

    void Update()
    {
        if (Time.frameCount % 10 != 0)
        {
            return;
        }
        
        if (_foodFish != null)
        {
            _agent.SetDestination(_foodFish.position);
        }
    }

    public void SetTarget(Transform foodFish)
    {
        if (_foodFish != null)
        {
            return;
        }

        _foodFish = foodFish;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        FishFood food = other.gameObject.GetComponent<FishFood>();
        if (food != null)
        {
            Destroy(other.gameObject);
        }
    }
}
