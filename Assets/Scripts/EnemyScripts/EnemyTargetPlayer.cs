using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargetPlayer : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    public Animator m_animator = null;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (AnimatorIsPlaying("Die"))
        {
            agent.SetDestination(transform.position);
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return m_animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
