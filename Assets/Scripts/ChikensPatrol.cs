using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChikensPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    private int pos = 0;
    public Transform[] destinos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(destinos[pos].position);

        if (Vector3.Distance(this.transform.position, destinos[pos].position) < 2)
        {
            pos++;
            if (pos == destinos.Length)
            {
                pos = 0;
            }
        }

    }
}
