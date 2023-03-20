using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : Action
{
    NavMeshAgent agent;
    private void Awake()
    {
        Initialization();
    }

    private void Initialization()
    {
        if (Initialized()) return;
        else
        {
            Initialize();
        }
    }
    private void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private bool Initialized()
    {
        if( agent == null) return false;
        return true;
    }

    private bool MoveTo(Vector3 destination)
    {
        return agent.SetDestination(destination);
    }
}
