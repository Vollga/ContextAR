using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour
{
    private NavMeshAgent aiController;
    private int currentPathIndex;

    public List<GameObject> path;

    private void Awake()
    {
        aiController = GetComponent<NavMeshAgent>();
        currentPathIndex = 0;     
    }

    private void Start()
    {
        Assert.IsNotNull(path, "AI requires path to follow");
        aiController.SetDestination(path[currentPathIndex].transform.position);
    }

    private void Update()
    {
        if (ReachedWaypoint()) {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        currentPathIndex = (currentPathIndex + 1) % path.Count;
        aiController.SetDestination(path[currentPathIndex].transform.position);
    }

    private bool ReachedWaypoint()
    {
        return aiController.remainingDistance < aiController.stoppingDistance;
    }
}
