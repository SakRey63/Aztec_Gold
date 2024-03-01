using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Fish : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    
    private Transform _target;

    void FixedUpdate()
    {
        if (Time.frameCount % 10 != 0)
        {
            return;
        }

        if (_target != null)
        {
            _agent.SetDestination(_target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PointFish point = other.gameObject.GetComponent<PointFish>();
        if (point != null)
        {
            _target = null;
        }
    }

    public void SetTarget(Transform target)
    {
        if (_target != null)
        {
            return;
        }
        _target = target;
    }
    
}
