using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChaseBehaviour : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private float _attackRange = 2f;
    private float _chaseRange = 10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 4;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.position);
        float _distance = Vector3.Distance(animator.transform.position, _player.position);
        if (_distance < _attackRange)
        {
            animator.SetBool("isAttacking", true);
        }
        if (_distance > 10)
        {
            animator.SetBool("isChasing", false);
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
        _agent.speed = 2;
    }
    
}
