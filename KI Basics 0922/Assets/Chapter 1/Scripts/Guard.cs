using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Guard : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    private Queue<Transform> queue;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        queue = new Queue<Transform>();

        foreach (Transform waypoint in waypoints)
        {
            queue.Enqueue(waypoint);
        }
        
        agent.destination = queue.Peek().position;

    }

    void Update()
    {
        Vector2 myPos, targetPos;

        myPos = new Vector2(transform.position.x, transform.position.z);
        targetPos = new Vector2(queue.Peek().position.x, queue.Peek().position.z);

        if((myPos-targetPos).sqrMagnitude <= 0.04f)
        {
            queue.Enqueue(queue.Dequeue());
            
        }
        agent.destination = queue.Peek().position;

    }
}
