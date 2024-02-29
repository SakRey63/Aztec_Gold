using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ork : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    private Transform _target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
