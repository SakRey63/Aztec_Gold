using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Shark : MonoBehaviour
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

    public void SetTarget(Transform target)
    {
        if (_target != null)
        {
            return;
        }
        _target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Fish fish = gameObject.GetComponent<Fish>();

        if (fish != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
