using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gatherer : MonoBehaviour
{
    Wood target = null;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            foreach(Wood woods in FindObjectsOfType<Wood>())
            {
                if (Vector3.Distance(this.transform.position, woods.transform.position) < 50)
                {
                    target = woods;
                }
            }
        }
        if(target != null)
        {
            agent.SetDestination(target.transform.position);   
        }
    }
}
