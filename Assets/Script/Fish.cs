using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _agent.SetDestination(_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
