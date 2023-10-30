using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    public Transform targetPosition; // Assign the target position in the Inspector

    private NavMeshAgent navMeshAgent;


    public GameObject prefab;

    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void DrawPath()
    {
        // Set the destination for the NavMeshAgent
        if (targetPosition != null)
        {
            navMeshAgent.SetDestination(targetPosition.position);
        }

        NavMeshPath path = new NavMeshPath();
        Vector3[] corners;

        Debug.Log(navMeshAgent.CalculatePath(targetPosition.position, path));

        if (navMeshAgent.CalculatePath(targetPosition.position, path))
        {
            corners = path.corners;
            for (int i = 0; i < corners.Length - 1; i++)
            {
                Instantiate(prefab, corners[i], Quaternion.identity);
                Debug.DrawLine(corners[i], corners[i + 1], Color.red, Mathf.Infinity);
            }
        }
    }
}
